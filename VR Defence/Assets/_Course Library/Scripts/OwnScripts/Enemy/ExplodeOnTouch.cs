using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    public GameObject pH; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(pH, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(pH, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
