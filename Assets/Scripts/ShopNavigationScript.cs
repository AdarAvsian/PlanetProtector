using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNavigationScript : MonoBehaviour
{
    public GameObject planetsPannel;
    public GameObject spaceshipsPannel;
    public GameObject backgroundsPannel;

    public enum Pannels {
        PLANETS,
        SPACESHIPS,
        BACKGROUNDS
    };

    private void navigate(Pannels pannel)
    {
        planetsPannel.SetActive(pannel == Pannels.PLANETS);
        spaceshipsPannel.SetActive(pannel == Pannels.PLANETS);
        backgroundsPannel.SetActive(pannel == Pannels.PLANETS);
    }
    public void navigatePlanets()
    {
        navigate(Pannels.PLANETS);
    }
    public void navigateSpaceships()
    {
        navigate(Pannels.SPACESHIPS);
    }
    public void navigateBackgrounds()
    {
        navigate(Pannels.BACKGROUNDS);
    }
}
