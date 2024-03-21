using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pannels
{
    PLANETS,
    SPACESHIPS,
    BACKGROUNDS
};

public class ShopNavigationScript : MonoBehaviour
{
    public GameObject planetsPannel;
    public GameObject spaceshipsPannel;
    public GameObject backgroundsPannel;
    private void Start()
    {
        navigate((Pannels) PlayerPrefs.GetInt("shopPannel"));
    }
    private void navigate(Pannels pannel)
    {
        planetsPannel.SetActive(pannel == Pannels.PLANETS);
        spaceshipsPannel.SetActive(pannel == Pannels.SPACESHIPS);
        backgroundsPannel.SetActive(pannel == Pannels.BACKGROUNDS);
    }
    public void navigatePlanets()
    {
        navigate(Pannels.PLANETS);
        PlayerPrefs.SetInt("shopPannel", (int) Pannels.PLANETS);
    }
    public void navigateSpaceships()
    {
        navigate(Pannels.SPACESHIPS);
        PlayerPrefs.SetInt("shopPannel", (int) Pannels.SPACESHIPS);
    }
    public void navigateBackgrounds()
    {
        navigate(Pannels.BACKGROUNDS);
        PlayerPrefs.SetInt("shopPannel", (int) Pannels.BACKGROUNDS);
    }
}
