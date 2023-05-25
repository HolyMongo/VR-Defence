using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class AINavigation : MonoBehaviour
{

    public NavMeshAgent agent;

    [Range(0, 100)] public float speed;
    [Range(0, 500)] public float walkRadious;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomLocation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomLocation());
        }
    }

    public Vector3 RandomLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadious;

        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadious, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}