using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroidScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -12;
    public LogicScript logic;
    public AudioManagerScript audio;
    public Rigidbody2D asteroidrb;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
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
        } else if (collision.collider.name == "Spaceship")
        {
            float damage = (asteroidrb.velocity.magnitude * asteroidrb.mass) * .05f;
            logic.decrementHealth(damage);
            audio.PlayTakingDamage();
            Destroy(gameObject);
        }
    }

}
