using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemy : MonoBehaviour
{
    HealthAndAttack hAA;
    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    [SerializeField] Transform[] gizmoPoints; // Add Gizmo Points here
    private int currentPointIndex;
    private Vector3 currentPoint;
    private bool isChasing = false;
    public float distance = 1;

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
        if (gizmoPoints.Length > 0)
        {
            currentPointIndex = 0;
            currentPoint = gizmoPoints[currentPointIndex].position;
        }
    }


    void Update()
    {
        if (!isChasing)
        {
            MoveBetweenGizmoPoints();
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
            transform.LookAt(playerPos.transform);
            float toClose = Vector3.Distance(playerPos.transform.position, transform.position);
            if (toClose <= chase)
            {
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

    public void MoveBetweenGizmoPoints()
    {
        if (gizmoPoints.Length > 0)
        {
            transform.LookAt(currentPoint);
            float toPoint = Vector3.Distance(currentPoint, transform.position);
            if (toPoint <= distance)
            {
                currentPointIndex++;
                if (currentPointIndex >= gizmoPoints.Length)
                {
                    currentPointIndex = 0;
                }
                currentPoint = gizmoPoints[currentPointIndex].position;
            }
            Vector3 moveDir = currentPoint - transform.position;
            rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.z).normalized * speed;
        }
    }
}

