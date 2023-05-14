using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    PlayerHealth playerHp;

    [SerializeField] private int hpToGain = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject player = collision.collider.gameObject;
            Debug.Log("Player gained health");
            playerHp = player.GetComponent<PlayerHealth>();
            playerHp.GainHealth(hpToGain);
            /*
            PlayerHp playerhp = player.GetComponent<PlayerHp>();
            playerhp.Hp -= attack;
            */
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            Debug.Log("Player gained health");
            playerHp = player.GetComponent<PlayerHealth>();
            playerHp.GainHealth(hpToGain);
            /*
            PlayerHp playerhp = player.GetComponent<PlayerHp>();
            playerhp.Hp -= attack;
            */
            Destroy(this.gameObject);
        }
    }
}
