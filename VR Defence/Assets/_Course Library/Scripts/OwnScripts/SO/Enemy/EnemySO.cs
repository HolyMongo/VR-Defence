using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy Creation/New Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] float hp;
    [SerializeField] float speed;
    [SerializeField] float attack;

    public float Hp()
    {
        return hp;
    }
    public float Speed()
    {
        return speed;
    }
    public float Attack()
    {
        return attack;
    }
}
