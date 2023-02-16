using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPos;
    [SerializeField] GameObject enemy;

    [SerializeField] float spawnerIntervals = 5;
    float Timer;

    private void Start()
    {
        Timer = spawnerIntervals;
    }
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = spawnerIntervals;
            int spawnPosition = Random.Range(0, spawnPos.Count);

            Instantiate(enemy, spawnPos[spawnPosition].position, Quaternion.identity);
        }
    }
}
