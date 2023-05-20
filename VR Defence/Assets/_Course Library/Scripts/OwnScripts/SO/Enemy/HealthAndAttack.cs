using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndAttack : MonoBehaviour
{
    [SerializeField] EnemySO enemy;
  //  SpawnEntity spawnEntity;

    float hp;
    float attack;
    float speed;

    PlayerHealth playerHp;
    [SerializeField] private HealthBar hpBar;

    private Renderer material;
    private bool isDissolving = false;
    private float fade = 1f;

    private SpawnEntity EntityTower;

    [SerializeField] private bool shouldUseSpawner = false;

    //Obj to instantiate when dying
    [SerializeField] private GameObject obj;
    void Start()
    {
        hp = enemy.Hp();
        attack = enemy.Attack();
        speed = enemy.Speed();

        material = GetComponentInChildren<Renderer>();
        if(shouldUseSpawner == true)
        {
            if (EntityTower == null)
            {
                EntityTower = GameObject.Find("SpawnPositions").GetComponent<SpawnEntity>();
            }
        }
        
    
        //  spawnEntity = GameObject.Find("EnemyBase").GetComponent<SpawnEntity>();
    }

    public EnemySO GetEnemySO()
    {
        return enemy;
    }

    public void ChangeEnemySO(EnemySO _enemy)
    {
        enemy = _enemy;
    }
    public void TakeDamage(float _attack)
    {
        hp = hp - _attack;
        if (hpBar != null)
        {
            hpBar.TakeDamage(_attack);
        }
        Debug.Log(hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDissolving = true;
        //   spawnEntity.OnEnemyDeath(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject player = collision.collider.gameObject;
            Debug.Log("Hit player");
            playerHp = player.GetComponent<PlayerHealth>();
            playerHp.TakeDamage(attack);
            /*
            PlayerHp playerhp = player.GetComponent<PlayerHp>();
            playerhp.Hp -= attack;
            */
        }
    }
    void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                //Fading
                Debug.Log("Fading");
                fade = 0f;
                isDissolving = false;
                if (EntityTower != null)
                {
                    Debug.Log("Decreasing");
                    EntityTower.OnEnemyDeath();
                }
                if(obj != null)
                {
                    Instantiate(obj, transform.position, Quaternion.identity);
                }
               
                Destroy(gameObject);                       
            }

            material.material.SetFloat("_Fade", fade);
        }
    }
}
