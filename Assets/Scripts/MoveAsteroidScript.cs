using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroidScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -12;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            logic.addScore(1);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Planet")
        {
            logic.gameOver();
        }
    }
}
