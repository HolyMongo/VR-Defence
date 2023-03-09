using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] Entity entity;

    GameObject playerPos;
    Rigidbody rB;
    [SerializeField] float speed = 5;
    [SerializeField] float chase = 3;
    void Start()
    {
        playerPos = GameObject.Find("XR Rig");
        rB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(playerPos.transform.position.x - transform.position.x, playerPos.transform.position.z - transform.position.z);
        float toClose = Vector2.Distance(playerPos.transform.position, transform.position);
      
        if (toClose <= chase)
        {
            rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.y).normalized * speed * Time.deltaTime;
        }

    }
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
