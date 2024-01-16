using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Transform> enemyPrefabs;
    public List<Transform> enemyOnScreen;
    public int minEnemiesCount;
    public int maxEnemiesCount;
    private void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject); 
            Instance = this;
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        EnemyCheck();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-3,3), 9, 0);
        var enemyPrefab = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPosition, Quaternion.identity);
        enemyOnScreen.Add(enemyPrefab);
    }

    public void EnemyCheck()
    {
        var enemyToSpawn = Random.Range(minEnemiesCount, maxEnemiesCount);
        if (enemyOnScreen.Count<=0)
            for (int i = 0; i < enemyToSpawn; i++)
                SpawnEnemy();
    }
}
