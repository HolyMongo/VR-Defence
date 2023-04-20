using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndAttack : MonoBehaviour
{
    [SerializeField] EnemySO enemy;

    float hp;
    float attack;
    float speed;

    PlayerHealth playerHp;
    void Start()
    {
        hp = enemy.Hp();
        attack = enemy.Attack();
        speed = enemy.Speed();
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
            Destroy(this.gameObject);
        }
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
