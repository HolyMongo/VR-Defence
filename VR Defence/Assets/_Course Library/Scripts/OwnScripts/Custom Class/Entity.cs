using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum EntityTypes
{
    LongRange,
    ShortRange
}
public class Entity
{
    public string _name;
    public float _hp;
    public float _speed;
    public float _attack;
    EntityTypes entityTypes;

}
