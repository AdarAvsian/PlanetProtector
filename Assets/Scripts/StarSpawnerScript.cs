using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerScript : MonoBehaviour
{
    public GameObject StarPrefab;
    public LogicScript logic;
    public int spawnRate = 10;
    private float timer = 0;

    private void FixedUpdate()
    {
        if (logic.isAlive && logic.isRunning)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnStar();
                timer = 0;
            }

        }
    }
    private void spawnStar()
    {
        var pos = new Vector2(Random.Range(logic.bottomLeftCorner.x, logic.topRightCorner.x), Random.Range(logic.bottomLeftCorner.y, logic.topRightCorner.y));
        Instantiate(StarPrefab, pos, Quaternion.identity);
    }
}
