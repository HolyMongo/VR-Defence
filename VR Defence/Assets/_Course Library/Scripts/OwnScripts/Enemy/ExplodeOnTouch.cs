using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    public GameObject pH;
    public bool useEnter = true;
    public bool useTrigger = false;

    private SpawnEntity EntityTower;

    [SerializeField] private bool shouldUseSpawner = false;

    void Start()
    {
       
        if (shouldUseSpawner == true)
        {
            if (EntityTower == null)
            {
                EntityTower = GameObject.Find("SpawnPositions").GetComponent<SpawnEntity>();
            }
        }


        //  spawnEntity = GameObject.Find("EnemyBase").GetComponent<SpawnEntity>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(useEnter)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Instantiate(pH, transform.position, Quaternion.identity);
                if (EntityTower != null)
                {
                    Debug.Log("Decreasing");
                    EntityTower.OnEnemyDeath();
                }
                Destroy(gameObject);
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(useTrigger)
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(pH, transform.position, Quaternion.identity);
                if (EntityTower != null)
                {
                    Debug.Log("Decreasing");
                    EntityTower.OnEnemyDeath();
                }
                Destroy(gameObject);
            }
        }
      
    }
}
