using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysicsDoor : MonoBehaviour
{
    public Transform target;

    Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        rB.MovePosition(target.transform.position);
    }
}
