using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text highScoreText;
    public Image muteBar;
    public Text totalStarsText;
    public SpriteRenderer planetSprite;
    public SpriteRenderer spaceshipSprite;
    public Image backgroundSprite;
    void Start()
    {
        setHighScoreText(PlayerPrefs.GetInt("highScore"));
        setStarsText(PlayerPrefs.GetInt("totalStars"));
        setPlanet(PlayerPrefs.GetInt("planet"));
        setSpaceship(PlayerPrefs.GetInt("spaceship"));
        setBackground(PlayerPrefs.GetInt("background"));
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

    public void incrementTotalStars(int amount)
    {
        int current = PlayerPrefs.GetInt("totalStars");
        PlayerPrefs.SetInt("totalStars", current + amount);
        setStarsText(current + amount);
        print("added");
    }

    void setStarsText(int amount)
    {
        totalStarsText.text = amount.ToString();
    }

    public bool canAfford(int amount)
    {
        return PlayerPrefs.GetInt("totalStars") >= amount;
    }

    public void decrementTotalStars(int amount)
    {
        int current = PlayerPrefs.GetInt("totalStars");
        PlayerPrefs.SetInt("totalStars", current - amount);
    }

    public void updatePlanet(int planetIndex)
    {
        PlayerPrefs.SetInt("planet", planetIndex);
        setPlanet(planetIndex);
    }

    void setPlanet(int planetIndex)
    {
        int index = planetIndex != 0 ? planetIndex : 1;
        planetSprite.sprite = Resources.Load<Sprite>("Planets/P" + index); 
    }

    public void updateSpaceship(int spaceshipIndex)
    {
        PlayerPrefs.SetInt("spaceship", spaceshipIndex);
        setSpaceship(spaceshipIndex);
    }

    void setSpaceship(int spaceshipIndex)
    {
        int index = spaceshipIndex != 0 ? spaceshipIndex : 1;
        spaceshipSprite.sprite = Resources.Load<Sprite>("Spaceships/S" + index);
    }

    public void updateBackground(int backgroundIndex)
    {
        PlayerPrefs.SetInt("background", backgroundIndex);
        setBackground(backgroundIndex);
    }

    void setBackground(int backgroundIndex)
    {
        int index = backgroundIndex != 0 ? backgroundIndex : 1;
        backgroundSprite.sprite = Resources.Load<Sprite>("Backgrounds/B" + index);
    }

    public void toggleVolume()
    {
        int newVolume = PlayerPrefs.GetInt("volumeOn") == 0 ? 1 : 0;
        muteBar.enabled = newVolume == 1 ? false : true;
        PlayerPrefs.SetInt("volumeOn", newVolume);
        Debug.Log(PlayerPrefs.GetInt("volumeOn"));
    }
    
}
