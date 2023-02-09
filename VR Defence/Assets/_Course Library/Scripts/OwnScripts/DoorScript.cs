using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject _doorPrefab;
    [SerializeField] private float _speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _doorPrefab.transform.Translate(0, _speed, 0);

        if (_doorPrefab.transform.position.y > 10)
        {
            Destroy(_doorPrefab);
        }
    }
}
