using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private weaponsSO weapon;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject enemy = collision.collider.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
        }
    }
}
