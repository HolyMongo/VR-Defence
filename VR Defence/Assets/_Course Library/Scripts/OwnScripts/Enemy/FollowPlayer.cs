using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;


    GameObject playerPos;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    private bool isChasing = false;


    void Start()
    {
        if (navMeshAgent = GetComponent<NavMeshAgent>())
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            InvokeRepeating("MoveToPlayer", 0, 1);
            navMeshAgent.speed = speed;
        }
        playerPos = GameObject.Find("XR Rig");
    }

    private void MoveToPlayer()
    {
        float toClose = Vector3.Distance(playerPos.transform.position, transform.position);
        if (toClose <= chase)
        {
            navMeshAgent.destination = playerPos.transform.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chase);
    }
}

