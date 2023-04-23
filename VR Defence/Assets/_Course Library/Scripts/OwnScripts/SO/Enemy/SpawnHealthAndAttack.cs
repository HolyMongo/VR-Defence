using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthAndAttack : MonoBehaviour
{
    [SerializeField] EnemySO enemy;
    SpawnEntity spawnEntity;

    float hp;
    float attack;
    float speed;

    PlayerHealth playerHp;
    void Start()
    {
        hp = enemy.Hp();
        attack = enemy.Attack();
        speed = enemy.Speed();
        spawnEntity = GameObject.Find("EnemyBase").GetComponent<SpawnEntity>();
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
        Destroy(gameObject);
        spawnEntity.OnEnemyDeath(transform);
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

    }
}