using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Creation/New Weapon")]
public class weaponsSO : ScriptableObject
{
    [SerializeField] private float attack;

    //public float Attack
    //{
    //    get
    //    {
    //        return attack;
    //    }
    //}

    public float Attack()
    {
        return attack;
    }
}
