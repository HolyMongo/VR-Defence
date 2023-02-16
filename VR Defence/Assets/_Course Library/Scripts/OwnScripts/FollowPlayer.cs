using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    void Start()
    {
        playerPos = GameObject.Find("Main Camera");
        rB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Vector3 moveDir = playerPos.transform.position - transform.position;
        Vector2 moveDir = new Vector2(playerPos.transform.position.x - transform.position.x, playerPos.transform.position.z - transform.position.z);

        rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.y).normalized * speed * Time.deltaTime;
    }
}
