using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUndergroundDoor : MonoBehaviour
{
    private int enemiesLeft;
    [SerializeField] private GameObject door;
    bool enemiesHasSpawned = false;

    private void Update()
    {
        enemiesLeft = (GameObject.FindGameObjectsWithTag("Enemy")).Length;
        if (enemiesLeft > 0)
        {
            enemiesHasSpawned = true;
        }

        if (enemiesLeft == 0 && enemiesHasSpawned && door.transform.rotation.x <= 0.9)
        {
            door.transform.Rotate(door.transform.rotation.x + 0.5f, 0, 0);
        }
    }




}
