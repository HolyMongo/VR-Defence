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


    float toClose;

    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
        rB = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
          toClose = Vector3.Distance(playerPos.transform.position, transform.position);

        if (!isChasing)
        {
            Wander();
        }
        else if(isChasing)
        {
            ChasePlayer();
        }
       

    }
    

    public void ChasePlayer()
    {
        
          //  float toClose = Vector3.Distance(playerPos.transform.position, transform.position);
            if (toClose <= chase)
            {
                transform.LookAt(playerPos.transform);
                
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
        if(toClose <= chase)
        {
            isChasing = true;
        }
        else
        {
           
        }
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chase);
    }
}

