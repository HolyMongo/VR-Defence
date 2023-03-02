using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPos;
    [SerializeField] List<Transform> count;
    [SerializeField] List<EnemySO> enemyTypes;
    [SerializeField] GameObject enemy;

    [SerializeField] float spawnerIntervals = 2;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("XR Rig");
        StartCoroutine(Spawn());
    }
    void FixedUpdate() // två problem som måste fixas. Om fiender är mer än x så ska inga mer spawnas
    {
       
    }
   private IEnumerator Spawn()
    {
        while(player != null)
        {
            int spawnPosition = Random.Range(0, spawnPos.Count);
            int type = Random.Range(0, enemyTypes.Count);
            if (count.Count < 40)
            {
                GameObject spawnedEnemy = Instantiate(enemy, spawnPos[spawnPosition].position, Quaternion.identity);
                spawnedEnemy.GetComponent<HealthAndAttack>().ChangeEnemySO(enemyTypes[type]);
                count.Add(enemy.transform);
            }
            yield return new WaitForSeconds(spawnerIntervals);
        }    
    }
}
