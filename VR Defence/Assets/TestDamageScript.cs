using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageScript : MonoBehaviour
{
    HealthAndAttack hAA;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<HealthAndAttack>().TakeDamage(10);
         
        }
    }
}
