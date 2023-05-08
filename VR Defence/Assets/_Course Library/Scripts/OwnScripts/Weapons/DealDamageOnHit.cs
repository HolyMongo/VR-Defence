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
        StartCoroutine("LifeTime");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject enemy = collision.collider.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
        }
        else if (collision.collider.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
    }

    IEnumerable LifeTime()
    {
        yield return new WaitForSeconds(lifeTimer);
        Destroy(transform.gameObject);
    }
}
