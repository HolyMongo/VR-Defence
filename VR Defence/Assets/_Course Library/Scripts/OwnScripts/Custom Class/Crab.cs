using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] Entity entity;

    public void TakeDamage(float _attack)
    {
        entity._hp -= _attack;
        if(entity._hp <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject player = collision.collider.gameObject;
            Debug.Log("Hit player");
            /*
            PlayerHp playerhp = player.GetComponent<PlayerHp>();
            playerhp.Hp -= attack;
            */
        }
    }
}
