using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;
    private float timer = 0;
    public LogicScript logic;

    void Start()
    {
        //SpawnAsteroids(1);
    }

    void Update()
    {
        if (logic.isAlive && logic.isRunning)
        {
            if (timer < logic.getSpawnRate())
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnAsteroids(Random.Range(1, 5));
                timer = 0;
            }
        }
    }

    private void SpawnAsteroids(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var pos = new Vector2(logic.topRightCorner.x, Random.Range(logic.bottomLeftCorner.y, logic.topRightCorner.y));
            GameObject chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            GameObject asteroid = Instantiate(chosenAsteroid, pos, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            float scaleChange = Random.Range(.3f, 1.2f);
            asteroid.transform.localScale *= scaleChange;

            int asteroidSpeed = Random.Range(logic.getMinAsteroidSpeed(),logic.getMaxAsteroidSpeed());
            Rigidbody2D asteroidrd = asteroid.GetComponent<Rigidbody2D>();
            asteroidrd.mass *= scaleChange;
            asteroidrd.AddForce(Vector2.left * asteroidSpeed, ForceMode2D.Impulse);
        }
    }
}
