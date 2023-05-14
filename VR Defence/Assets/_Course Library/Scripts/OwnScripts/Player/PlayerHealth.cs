using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private PlayerSO playerSo;
    [SerializeField] HealthBar hpBar;
    private float hp;
    private float startHp;

    void Start()
    {
        hp = playerSo.Hp();
        startHp = hp;
    }


    public void TakeDamage(float _attack)
    {
        hp -= _attack;
        hpBar.TakeDamage(_attack);
        if (hp <= 0)
        {
            Death();
        }
    }

    public void GainHealth(float _health)
    {      
        if(hp < startHp)
        {
            hp += _health;
            hpBar.GainHealth(_health);
        }     
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            Death();
        }
    }

}