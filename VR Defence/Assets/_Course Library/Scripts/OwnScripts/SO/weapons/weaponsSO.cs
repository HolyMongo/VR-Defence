using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Creation/New Weapon")]
public class weaponSO : ScriptableObject
{
    [SerializeField] float attack;

    public float Attack()
    {
        return attack;
    }
}
