using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationScript : MonoBehaviour
{
    public GameObject storeScreen;
    public GameObject inGame;

    public void navigateGame()
    {
        storeScreen.SetActive(false);
        inGame.SetActive(true);
    }

    public void navigateStoreScreen()
    {
        storeScreen.SetActive(true);
        inGame.SetActive(false);
    }

}
