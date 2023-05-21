using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnHit : MonoBehaviour
{
    [SerializeField] weaponsSO weapon;
    [SerializeField] float lifeTimer;
    private void Start()
    {
        if (lifeTimer == 0)
        {
            lifeTimer = 2;
        }
        Invoke("LifeTime", lifeTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject enemy = collision.collider.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
            Destroy(transform.gameObject);
        }
        else if (collision.collider.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            GameObject player = collision.collider.gameObject;
            player.GetComponent<PlayerHealth>().TakeDamage(weapon.Attack());
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
            Destroy(transform.gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().TakeDamage(weapon.Attack());
            Destroy(transform.gameObject);
        }
    }

    public void LifeTime()
    {    
        Destroy(transform.gameObject);
    }
}
