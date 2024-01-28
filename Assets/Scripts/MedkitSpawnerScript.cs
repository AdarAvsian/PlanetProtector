using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawnerScript : MonoBehaviour
{
    public GameObject MedkitPrefab;
    public LogicScript logic;
    public int spawnRate = 20;
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
                spawnMedkit();
                timer = 0;
            }
        
        }
    }
    private void spawnMedkit()
    {
        var pos = new Vector2(Random.Range(logic.bottomLeftCorner.x, logic.topRightCorner.x), Random.Range(logic.bottomLeftCorner.y, logic.topRightCorner.y));
        Instantiate(MedkitPrefab, pos, Quaternion.identity);
    }

    
}
