using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text highScoreText;
    public Image soundImg;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    void Start()
    {
        setHighScoreText(PlayerPrefs.GetInt("highScore"));
    }
    private void setHighScoreText(int score)
    {
        highScoreText.text = "High Score: " + score.ToString();
    }
    void updateHighScore(int newScore)
    {
        PlayerPrefs.SetInt("highScore", newScore);
        setHighScoreText(newScore);
    }
    void incrementTotalStars(int amount)
    {
        int current = PlayerPrefs.GetInt("totalStars");
        PlayerPrefs.SetInt("totalStars", current + amount);
    }
    bool canAfford(int amount)
    {
        return PlayerPrefs.GetInt("totalStars") >= amount;
    }
    void decrementTotalStars(int amount)
    {
        if (canAfford(amount))
        {
            int current = PlayerPrefs.GetInt("totalStars");
            PlayerPrefs.SetInt("totalStars", current - amount);
        }
    }
    void updatePlanet(string  planetName)
    {
        PlayerPrefs.SetString("planet", planetName);
    }
    public void toggleVolume()
    {
        int newVolume = PlayerPrefs.GetInt("volumeOn") == 0 ? 1 : 0;
        soundImg.sprite = newVolume == 1 ? soundOnSprite : soundOffSprite;
        PlayerPrefs.SetInt("volumeOn", newVolume);
    }
}
