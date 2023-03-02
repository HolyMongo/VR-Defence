using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
        rB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Vector3 moveDir = playerPos.transform.position - transform.position;
        // Problem fiender ska bara jaga om spelare är x nära dem
        Vector2 moveDir = new Vector2(playerPos.transform.position.x - transform.position.x, playerPos.transform.position.z - transform.position.z);
        float toClose = Vector2.Distance(playerPos.transform.position, transform.position);
        if (toClose <= chase)
        {      
            rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.y).normalized * speed * Time.deltaTime;
        }    
    }
    private void OnCollisionEnter(Collision collision) // Add enemy damage player?
    {
        
    }
}
