using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Creation/New Player")]
public class PlayerSO : ScriptableObject
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
}
