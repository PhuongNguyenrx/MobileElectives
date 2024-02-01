using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Transform> enemyPrefabs;
    public List<Transform> enemyOnScreen;
    public int minEnemiesCount;
    public int maxEnemiesCount;
    
    public int score;
    public TextMeshProUGUI scoreText;

    bool isPause = false;
    public GameObject startMenu;

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
        SwitchGameState();
    }

    private void Update()
    {
        if (isPause && Input.touchCount > 0)
            SwitchGameState();
    }
    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-3,3), 9, 0);
        var enemyPrefab = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPosition, Quaternion.identity);
        enemyOnScreen.Add(enemyPrefab);
    }

    public void EnemyCheck()
    {
        scoreText.text = score.ToString();
        var enemyToSpawn = Random.Range(minEnemiesCount, maxEnemiesCount);
        if (enemyOnScreen.Count<=0)
            for (int i = 0; i < enemyToSpawn; i++)
                SpawnEnemy();
    }

    void SwitchGameState()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            EnemyCheck();
        }
        else
            Time.timeScale = 0;
        isPause= !isPause;
        startMenu.SetActive(isPause);
    }
    public void GameOver()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExtraLife()
    {

    }
}
