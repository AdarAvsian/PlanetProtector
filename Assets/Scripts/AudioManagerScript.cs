using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource _titleMusic;
    [SerializeField] private AudioSource _gameMusic;
    private bool _titleMusicPlaying = false;
    private bool _gameMusicPlaying = false;

    [Header("Sound Effects")]
    [SerializeField] private AudioSource takingDamage;
    [SerializeField] private AudioSource gettingStar;

    private bool volumeEnabled()
    {
        return PlayerPrefs.GetInt("volumeOn") == 1;
    }
    public void PlayTakingDamage()
    {
        if (volumeEnabled())
        {
            takingDamage.Play();
        }
    }
    public void PlayGettingStar()
    {
        if (volumeEnabled())
        {
            gettingStar.Play();
        }
    }
}
