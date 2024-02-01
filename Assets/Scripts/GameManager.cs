using System;
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
    int currentwave=0;
    
    public int score;
    public TextMeshProUGUI scoreText, endScoreText, highscoreText;
    private const string HighscoreKey = "Highscore";

    bool isPause = false;
    public GameObject startMenu;
    public GameObject endMenu;

    public static Action OnExtraLife;

    private void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject); 
            Instance = this;
        }
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SwitchGameState();
        LoadHighscore();
    }

    private void Update()
    {
        if (isPause && Input.touchCount > 0)
            SwitchGameState();
    }
    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-3,3), 9, 0);
        var enemyPrefab = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)], spawnPosition, Quaternion.identity);
        enemyOnScreen.Add(enemyPrefab);
    }

    public void EnemyCheck()
    {
        scoreText.text = score.ToString();
        var enemyToSpawn = UnityEngine.Random.Range(minEnemiesCount + Mathf.RoundToInt(currentwave/2), maxEnemiesCount + Mathf.RoundToInt(currentwave / 2));
        if (enemyOnScreen.Count <= 0)
        {
            for (int i = 0; i < enemyToSpawn; i++)
                SpawnEnemy();
            currentwave++;
        }
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
        endMenu.SetActive(true);
        endScoreText.text = score.ToString();

        int currentHighscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt(HighscoreKey, score);
            PlayerPrefs.Save();
        }
    }

    private void LoadHighscore()
    {
        int highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        highscoreText.text = highscore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExtraLife()
    {
        endMenu.SetActive(false);
        OnExtraLife?.Invoke();
    }
}
