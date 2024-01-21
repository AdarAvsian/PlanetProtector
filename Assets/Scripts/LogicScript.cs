using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public PlayerScript player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject navigation;
    public Image health;
    public GameObject healthBar;
    public Vector3 topRightCorner;
    public Vector3 bottomLeftCorner;

    private int playerScore;
    public bool isAlive = true;
    public bool isRunning = false;
    private float playerHealth = 100f;
    private int minAsteroidSpeed;
    private int maxAsteroidSpeed;
    private int minNumAsteroids;
    private int maxNumAsteroids;
    private float spawnRate = 5;
    private int difficulty = 1;

    public void Start()
    {
        topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
    }
    public void addScore(int scoreToAdd)
    {
        if (isAlive)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();

            if (playerScore >= 10 * difficulty)
            {
                incrementDifficulty();
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        healthBar.SetActive(false);
        gameOverScreen.SetActive(true);
        isAlive = false;
        difficulty = 1;
        if (playerScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }
    }

    public void startGame()
    {
        isRunning = true;
        navigation.SetActive(false);
        healthBar.SetActive(true);
        scoreText.enabled = true;
        highScoreText.enabled = true;
        manageDifficulty();
    }

    public void decrementHealth(float amount)
    {
        playerHealth -= amount;
        health.fillAmount = playerHealth / 100f;
        if (playerHealth < 0)
        {
            gameOver();
        }
    }

    public void restoreHealth()
    {
        playerHealth = 100f;
        health.fillAmount = 1;
    }
    private void incrementDifficulty()
    {
        difficulty++;
        manageDifficulty();
    }
    private void manageDifficulty()
    {
        maxAsteroidSpeed = Mathf.Min(2000, 500 * difficulty);
        minAsteroidSpeed = Mathf.Min(1000, 200 * difficulty);
        maxNumAsteroids = Mathf.Min(10, difficulty * 3);
        minNumAsteroids = Mathf.Min(6, difficulty);
        spawnRate =   5 - (difficulty * .5f);
    }

    public float getSpawnRate()
    {
        return spawnRate;
    }
    public int getMaxAsteroidSpeed()
    {
        return maxAsteroidSpeed;
    }
    public int getMinAsteroidSpeed()
    {
        return minAsteroidSpeed;
    }
    public int getMaxNumAsteroids()
    {
        return maxNumAsteroids;
    }
    public int getMinNumAsteroids()
    {
        return minNumAsteroids;
    }
}
