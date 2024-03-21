using LightScrollSnap;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class StoreManagerScript : MonoBehaviour
{
    public Text priceText;
    public Button actionBtn;
    public PlayerScript playerManager;
    public ShopNavigationScript shopNavigation;
    public GameObject buyAction;
    public GameObject useAction;
    public ScrollSnap planetsScrollSnap;
    public int planetIndex;
    public GameObject planetsContent;
    public ScrollSnap spaceshipsScrollSnap;
    public int spaceshipIndex;
    public GameObject spaceshipContent;
    public ScrollSnap backgroundsScrollSnap;
    public int backgroundsIndex;
    public GameObject backgroundsContent;
    
    void Start()
    {
        HashSet<char> boughtPlanets = new HashSet<char>(PlayerPrefs.GetString("boughtPlanets").ToCharArray());
        HashSet<char> boughtSpaceships = new HashSet<char>(PlayerPrefs.GetString("boughtSpaceships").ToCharArray());
        HashSet<char> boughtBackgrounds = new HashSet<char>(PlayerPrefs.GetString("boughtBackgrounds").ToCharArray());

        planetsScrollSnap.OnItemSelected.AddListener((go,index) => {
            planetIndex = index + 1;
            priceText.text = planetsPrices[planetIndex].ToString();
       
            if (boughtPlanets.Contains(planetIndex.ToString()[0]))
            {
                useAction.SetActive(true);
                buyAction.SetActive(false);
            } else
            {
                useAction.SetActive(false);
                buyAction.SetActive(true);
            }
        });

        spaceshipsScrollSnap.OnItemSelected.AddListener((go, index) => {
            spaceshipIndex = index + 1;
            priceText.text = spaceshipsPrices[spaceshipIndex].ToString();

            if (boughtSpaceships.Contains(spaceshipIndex.ToString()[0]))
            {
                useAction.SetActive(true);
                buyAction.SetActive(false);
            }
            else
            {
                useAction.SetActive(false);
                buyAction.SetActive(true);
            }
        });

        backgroundsScrollSnap.OnItemSelected.AddListener((go, index) => {
            backgroundsIndex = index + 1;
            priceText.text = backgroundsPrices[backgroundsIndex].ToString();

            if (boughtBackgrounds.Contains(backgroundsIndex.ToString()[0]))
            {
                useAction.SetActive(true);
                buyAction.SetActive(false);
            }
            else
            {
                useAction.SetActive(false);
                buyAction.SetActive(true);
            }
        });
    }
    public void buy()
    {
        switch ((Pannels)PlayerPrefs.GetInt("shopPannel")) {
            case Pannels.PLANETS: 
                buyPlanet(); 
                break;
            case Pannels.SPACESHIPS:
                buySpaceship();
                break;
            case Pannels.BACKGROUNDS:
                buyBackground();
                break;
        }
        
    }
    public void use()
    {
        switch ((Pannels)PlayerPrefs.GetInt("shopPannel"))
        {
            case Pannels.PLANETS:
                usePlanet();
                break;
            case Pannels.SPACESHIPS:
                useSpaceship();
                break;
            case Pannels.BACKGROUNDS:
                useBackground();
                break;
        }
    }

    public void usePlanet()
    {
        int oldIndex = PlayerPrefs.GetInt("planet");
        playerManager.updatePlanet(planetIndex);
        planetsContent.gameObject.transform.GetChild(oldIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        planetsContent.gameObject.transform.GetChild(planetIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void buyPlanet()
    {
        if (playerManager.canAfford(planetsPrices[planetIndex])) {
            string currBoughtPlanets = PlayerPrefs.GetString("boughtPlanets");
            PlayerPrefs.SetString("boughtPlanets", currBoughtPlanets + planetIndex);
            playerManager.decrementTotalStars(planetsPrices[planetIndex]);
            Debug.Log("bought planet");
        } else
        {
            Debug.Log("cannot afford planet");
        }
        
    }
    public void useSpaceship()
    {
        int oldIndex = PlayerPrefs.GetInt("spaceship");
        playerManager.updateSpaceship(spaceshipIndex);
        spaceshipContent.gameObject.transform.GetChild(oldIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        spaceshipContent.gameObject.transform.GetChild(spaceshipIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void buySpaceship()
    {
        if (playerManager.canAfford(spaceshipsPrices[spaceshipIndex]))
        {
            string currBoughtSpaceships = PlayerPrefs.GetString("boughtSpaceships");
            PlayerPrefs.SetString("boughtSpaceships", currBoughtSpaceships + spaceshipIndex);
            playerManager.decrementTotalStars(spaceshipsPrices[spaceshipIndex]);
            Debug.Log("bought spaceship");
        }
        else
        {
            Debug.Log("cannot afford spaceship");
        }

    }

    public void useBackground()
    {
        int oldIndex = PlayerPrefs.GetInt("background");
        playerManager.updateBackground(backgroundsIndex);
        backgroundsContent.gameObject.transform.GetChild(oldIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        backgroundsContent.gameObject.transform.GetChild(backgroundsIndex - 1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void buyBackground()
    {
        if (playerManager.canAfford(backgroundsPrices[backgroundsIndex]))
        {
            string currBoughtBackgrounds = PlayerPrefs.GetString("boughtBackgrounds");
            PlayerPrefs.SetString("boughtBackgrounds", currBoughtBackgrounds + backgroundsIndex);
            playerManager.decrementTotalStars(backgroundsPrices[backgroundsIndex]);
            Debug.Log("bought background");
        }
        else
        {
            Debug.Log("cannot afford background");
        }

    }


    Dictionary<int, int> planetsPrices = new Dictionary<int, int> { 
        { 1,  0    },
        { 2,  100  },
        { 3,  200  },
        { 4,  500  },
        { 5,  750  },
        { 6,  1000 },
        { 7,  1250 },
        { 8,  1500 },
        { 9,  1750 },
        { 10, 2000 },
        { 11, 2590 },
        { 12, 3000 },
        { 13, 3500 },
        { 14, 4000 },
        { 15, 5000 },
    };

    Dictionary<int, int> spaceshipsPrices = new Dictionary<int, int> {
        { 1,  0    },
        { 2,  100  },
        { 3,  200  },
        { 4,  500  },
        { 5,  750  },
        { 6,  1000 },
        { 7,  1250 },
        { 8,  1500 },
        { 9,  1750 },
        { 10, 2000 },
        { 11, 2590 },
        { 12, 3000 },
        { 13, 3500 },
        { 14, 4000 },
        { 15, 5000 },
    };

    Dictionary<int, int> backgroundsPrices = new Dictionary<int, int> {
        { 1,  0    },
        { 2,  1  },
        { 3,  1  },
        { 4,  1  },
        { 5,  1  },
        
    };


}
