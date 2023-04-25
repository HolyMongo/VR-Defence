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
    public void Wander()
    {
    
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chase);
    }
}

