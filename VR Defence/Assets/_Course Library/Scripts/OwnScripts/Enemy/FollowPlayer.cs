using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   
    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    private bool isChasing = false;


   

    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
        rB = GetComponent<Rigidbody>();
        
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
        
            float toClose = Vector3.Distance(playerPos.transform.position, transform.position);
            if (toClose <= chase)
            {
                transform.LookAt(playerPos.transform);
                isChasing = true;
                Vector3 moveDir = playerPos.transform.position - transform.position;

                rB.AddForce(moveDir.normalized * speed, ForceMode.Force);
            }
            else
            {
                isChasing = false;
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

