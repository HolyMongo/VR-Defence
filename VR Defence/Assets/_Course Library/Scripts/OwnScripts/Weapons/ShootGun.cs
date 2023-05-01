using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{

    // So Reference
    [Header("SO Reference")]
    [SerializeField] weaponsSO weapon;
    float damage;
    // Just Things
    [Header("Things")]
    [SerializeField] private float speed = 40f;
    [SerializeField] private GameObject bullet;
    [SerializeField] Transform Barrel;

    // Layer
    [Header("Layer")]
    [SerializeField] LayerMask targetLayer;

    // Audio
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


    void Start()
    {
        damage = weapon.Attack();
    }

    
    void Update()
    {       
       
    }

    public void HitObject()
    {
        GameObject spawnedBullet = Instantiate(bullet, Barrel.position, Quaternion.identity);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * Barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 10);
    }  
}
