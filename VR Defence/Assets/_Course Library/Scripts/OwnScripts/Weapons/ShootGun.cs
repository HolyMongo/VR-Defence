using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{

    [SerializeField] weaponsSO weapon;
    float damage;

    [SerializeField] Transform bulletExitAndDirection;
    float rayDistance = 10f;
    [SerializeField] LayerMask targetLayer;
    void Start()
    {
        damage = weapon.Attack();
    }

    
    void Update()
    {       
        
    }

    public void HitObject()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(bulletExitAndDirection.position, bulletExitAndDirection.forward, out hit, rayDistance))
        {
            GameObject enemy = hit.transform.gameObject;
            HealthAndAttack enemyHealth = enemy.GetComponent<HealthAndAttack>();
            enemyHealth.TakeDamage(damage);
            Debug.Log("hit an object");
        }
    }
}
