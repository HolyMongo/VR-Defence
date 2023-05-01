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

    private Renderer material;
    private bool isDissolving = false;
    private float fade = 1f;

    [SerializeField] private SpawnEntity EntityTower;
    void Start()
    {
        hp = enemy.Hp();
        attack = enemy.Attack();
        speed = enemy.Speed();

        material = GetComponentInChildren<Renderer>();
        EntityTower = GameObject.Find("SpawnPositions").GetComponent<SpawnEntity>();
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
                Destroy(gameObject);
                if(EntityTower != null)
                {
                    EntityTower.OnEnemyDeath();
                }
              
            }

            material.material.SetFloat("_Fade", fade);
        }
    }
}
