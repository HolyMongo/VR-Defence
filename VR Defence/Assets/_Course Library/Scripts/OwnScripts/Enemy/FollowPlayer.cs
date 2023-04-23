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
        ChasePlayer();

    }
    private void OnCollisionEnter(Collision collision) // Add enemy damage player?
    {

    }

    public void ChasePlayer()
    {
        if (hAA != null)
        {

            //Vector3 moveDir = playerPos.transform.position - transform.position;

            Vector2 moveDir = new Vector2(playerPos.transform.position.x - transform.position.x, playerPos.transform.position.z - transform.position.z);
            float toClose = Vector2.Distance(playerPos.transform.position, transform.position);
            if (toClose <= chase)
            {
                rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.y).normalized * hAA.GetEnemySO().Speed();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chase);
    }
}

