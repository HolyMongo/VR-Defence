using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Color gizmosColor = Color.green;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private bool spawnEnabled = false;

    [SerializeField] List<EnemySO> enemyTypes;

    private float timeSinceLastSpawn = 0f;
    //[SerializeField] List<Transform> currentEnemies;
    private int currentEnemyCount = 0;
    private int newCurrentEnemies;

    [SerializeField] private float yPosition = 0f;

    private Renderer material;
    private bool isDissolving = false;
    private float fade = 1f;

    float hp = 100;
    private void Start()
    {
        material = GetComponent<Renderer>();
    }

    public void TakeDamage(float _attack)
    {
        hp = hp - _attack;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDissolving = true;      
    }
    private void Update()
    {
        if (!spawnEnabled)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                Destroy(gameObject);

            }

            material.material.SetFloat("_Fade", fade);
        }
      
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        int childCount = transform.childCount;
        if (childCount < 3)
        {
            return;
        }
        Vector3[] positions = new Vector3[childCount];
        for (int i = 0; i < childCount; i++)
        {
            positions[i] = transform.GetChild(i).position;
        }

        for (int i = 0; i < childCount; i++)
        {
            int j = (i + 1) % childCount;
            Gizmos.DrawLine(positions[i], positions[j]);
        }
    }

    private void SpawnEnemy()
    {
        int type = Random.Range(0, enemyTypes.Count);
      
        Vector3 randomPosition = GetRandomPositionInsideGizmos();
        GameObject spawnedEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        spawnedEnemy.GetComponent<HealthAndAttack>().ChangeEnemySO(enemyTypes[type]);
      
       
        currentEnemyCount++;
        Debug.Log(currentEnemyCount);
        if (currentEnemyCount >= maxEnemies)
        {
            spawnEnabled = false;
        }
    }
    public void OnEnemyDeath()
    {
       
        currentEnemyCount--;

        if (currentEnemyCount <= maxEnemies)
        {
            spawnEnabled = true;
        }
    }



    private Vector3 GetRandomPositionInsideGizmos()
    {
        Vector3[] positions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            positions[i] = transform.GetChild(i).position;
        }

        Vector3 centroid = Vector3.zero;
        for (int i = 0; i < positions.Length; i++)
        {
            centroid += positions[i];
        }
        centroid /= positions.Length;

        float maxRadius = 0f;
        for (int i = 0; i < positions.Length; i++)
        {
            float radius = Vector3.Distance(centroid, positions[i]);
            if (radius > maxRadius)
            {
                maxRadius = radius;
            }
        }

        Vector3 randomPosition = Vector3.zero;
        bool foundValidPosition = false;
        int numAttempts = 0;

        while (!foundValidPosition && numAttempts < 10)
        {
            randomPosition = centroid + Random.insideUnitSphere * maxRadius;
            randomPosition.y = yPosition;

            if (IsPositionInsideGizmos(randomPosition))
            {
                foundValidPosition = true;
            }
            numAttempts++;
        }

        return randomPosition;
    }

    private bool IsPositionInsideGizmos(Vector3 position)
    {
        Vector3[] positions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            positions[i] = transform.GetChild(i).position;
        }

        int numVertices = positions.Length;
        int j = numVertices - 1;
        bool inside = false;
        for (int i = 0; i < numVertices; i++)
        {
            if ((positions[i].z < position.z && positions[j].z >= position.z ||
                 positions[j].z < position.z && positions[i].z >= position.z) &&
                (positions[i].x
            + (position.z - positions[i].z) / (positions[j].z - positions[i].z) * (positions[j].x - positions[i].x) < position.x))
            {
                inside = !inside;
            }
            j = i;
        }

        return inside;
    }
}

