using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnHit : MonoBehaviour
{
    [SerializeField] weaponsSO weapon;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Entity"))
        {
            GameObject enemy = collision.collider.gameObject;
            enemy.GetComponent<HealthAndAttack>().TakeDamage(weapon.Attack());
        }
    }
}
