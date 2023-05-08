using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretFollowPlayer : MonoBehaviour
{
    HealthAndAttack hAA;
    GameObject playerPos;
    
    
    

    //Shooting
    public float shootingRange = 10f;
    public float BulletsBeforeReloading = 30f;
    public float shootingDurationBetweenBullets = 1f;
    public float reloadDuration = 5f;
   
    public GameObject projectilePrefab;
    private bool isShooting = false;
    public GameObject gun;
    public GameObject gunPoint;

    //Text
    [SerializeField] TextMeshProUGUI barText;
    public GameObject barObj;
    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
       
        if (hAA == null)
        {
            try
            {
                hAA = GetComponent<HealthAndAttack>();
            }
            catch (System.Exception)
            {
                Debug.Log("failed to get component!");
                throw;
            }
        }
        barText.text = "0";
        barObj.SetActive(false);
    }


    void Update()
    {
        if (!isShooting)
        {
            Wander();
        }
        
            ChasePlayer();
        
       

    }
    private void OnCollisionEnter(Collision collision) // Add enemy damage player?
    {

    }

    public void ChasePlayer()
    {
        if (hAA != null)
        {
            float toClose = Vector3.Distance(playerPos.transform.position, transform.position);
            if (toClose <= shootingRange)
            {
                transform.LookAt(playerPos.transform);
                gun.transform.LookAt(playerPos.transform);
                           
                if (!isShooting)
                {
                    isShooting = true;
                    StartCoroutine(ShootRoutine());
                    
                }
            }
            else
            {
              
                isShooting = false; // Stop shooting when the player is out of range
            }
        }
    }
    public void Wander()
    {

    }
    private IEnumerator ShootRoutine()
    {

       
        for (int i = 0; i < BulletsBeforeReloading; i++)
        {
            Shoot();
            yield return new WaitForSeconds(shootingDurationBetweenBullets);
        }
        // Reload
        barObj.SetActive(true);
        float remainingTime = reloadDuration;

        while (remainingTime > 0)
        {
            barText.text = remainingTime.ToString();
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        barText.text = "0";
        isShooting = false;
        barObj.SetActive(false);
    }

    private void Shoot()
    {
        // Instantiate and shoot a projectile towards the player
        GameObject projectile = Instantiate(projectilePrefab, gunPoint.transform.position, Quaternion.identity);
        Vector3 directionToPlayer = (playerPos.transform.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = directionToPlayer * 10f;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }









}

