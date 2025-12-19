using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [Header("Spawn Settings")]
    public float spawnDelay = 10f;
    public int maxAliveEnemies = 2;

    private List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

 
            aliveEnemies.RemoveAll(enemy => enemy == null);

            if (aliveEnemies.Count < maxAliveEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null)
            return;

        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);

        aliveEnemies.Add(enemy);
    }
}
