using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public LogicScript logic;
    private float timer = 0;
    private float timeGiven = 5;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void FixedUpdate()
    {
        if (timer < timeGiven)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Spaceship")
        {
            //add star
            Destroy(gameObject);
        }
    }
}
