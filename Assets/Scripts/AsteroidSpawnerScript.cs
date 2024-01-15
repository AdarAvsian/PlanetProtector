using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;
    public float spawnRate = 5;
    public float asteroidSpeed = 2000;
    private float timer = 0;
    public LogicScript logic;

    void Start()
    {
        SpawnAsteroids(1);
    }

    void Update()
    {
        if (logic.isAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnAsteroids(1);
                timer = 0;
            }
        }
    }

    private void SpawnAsteroids(int amount)
    {
        Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        var pos = new Vector2(topRightCorner.x, Random.Range(0, topRightCorner.y));

        for (int i = 0; i < amount; i++)
        {
            GameObject chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            GameObject asteroid = Instantiate(chosenAsteroid, pos, Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.left * asteroidSpeed, ForceMode2D.Impulse);

            // You can still manipulate asteroid afterwards like .AddComponent etc
        }
    }
}
