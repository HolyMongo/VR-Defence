using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    HealthAndAttack hAA;
    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    private bool isChasing = false;


    //Wander
    //private bool isWandering = false;
    //private bool isRotatingLeft = false;
    //private bool isRotatingRight = false;
    //private bool isWalking = false;

    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
        rB = GetComponent<Rigidbody>();
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
    }


    void Update()
    {
        if (!isChasing)
        {
          //  StartCoroutine(Wander());
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
            if (toClose <= chase)
            {
                transform.LookAt(playerPos.transform);
                isChasing = true;
                Vector3 moveDir = playerPos.transform.position - transform.position;
                rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.z).normalized * speed;
            }
            else
            {
                isChasing = false;
            }
        }
    }
  //  IEnumerator Wander()
    //{
    //    int rotationTime = Random.Range(1, 3);
    //    int rotateWait = Random.Range(1, 3);
    //    int rotateRange = Random.Range(1, 2);
    //    int walkWait = Random.Range(1, 3);
    //    int walkTime = Random.Range(1, 3);

    //    isWandering = true;

    //    yield return new WaitForSeconds(walkWait);

    //    isWalking = true;

    //    yield return new WaitForSeconds(walkTime);

    //    isWalking = false;

    //    yield return new WaitForSeconds(rotateWait);

    //    if(rotateRange == 1)
    //    {
    //        isRotatingLeft = true;
    //        yield return new WaitForSeconds(rotationTime);
    //        isRotatingLeft = false;
    //    }
    //    if (rotateRange == 2)
    //    {
    //        isRotatingRight = true;
    //        yield return new WaitForSeconds(rotationTime);
    //        isRotatingRight = false;
    //    }

    //    isWandering = false;

    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chase);
    }
}

