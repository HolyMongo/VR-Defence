using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private weaponsSO weapon;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject enemy = collision.collider.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
        }
        else if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
