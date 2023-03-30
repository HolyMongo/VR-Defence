using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{
    public XRController rightHand;
    public InputHelpers.Button button;

    [SerializeField] weaponSO weapon;
    float damage;
    [SerializeField] XRButton triggerKey;

    Transform bulletExitAndDirection;
    float rayDistance = 10f;
    [SerializeField] LayerMask targetLayer;
    void Start()
    {
        damage = weapon.Attack();
    }

    
    void Update()
    {
        bool pressed;
        rightHand.inputDevice.IsPressed(button, out pressed);

        if (pressed)
        {
            Debug.Log("Hello - " + button);
            if (HitObject())
            {
                GameObject enemy = HitObject();
                HealthAndAttack enemyHealth = enemy.GetComponent<HealthAndAttack>();
                enemyHealth.TakeDamage(damage);
            }
        }
        
    }

    public GameObject HitObject()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(bulletExitAndDirection.position, bulletExitAndDirection.forward, out hit, rayDistance))
        {
            Debug.Log("hit an object");
        }

        return hit.transform.gameObject;
    }
}
