using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpaceshipScript : MonoBehaviour
{
    public Rigidbody2D spaceshiprb;
    public Rigidbody2D planetrb;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    public int moveSpeed = 700;
    public int grappleStrength = 2;
    public LogicScript logic;
    public float rotation;
    private Vector2 planetPosition;
    private bool gameStarted = false;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }


    private void FixedUpdate()
    {
        GrapplePlanet();
        MoveSpaceship();
        // RestoreRotation();
        if (gameStarted)
        {
            logic.startGame();
        }
    }

    private void handleGame()
    {
        if (!gameStarted) {
            logic.startGame();
            gameStarted = true;
            print("started");
        }
    }

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spaceshiprb.AddForce(Vector3.right * moveSpeed);
            handleGame();
            
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spaceshiprb.AddForce(Vector3.left * moveSpeed);
            handleGame();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spaceshiprb.AddForce(Vector3.down * moveSpeed);
            handleGame();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spaceshiprb.AddForce(Vector3.up * moveSpeed);
            handleGame();
        }
    }

    private void GrapplePlanet()
    {
        planetPosition = planetrb.transform.position;

        if (Input.GetKey(KeyCode.Space))
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, planetPosition);
            Vector2 direction = (Vector2) transform.position - planetPosition;
            planetrb.AddForce(direction * grappleStrength);

        } else
        {
            lineRenderer.positionCount = 0;
        }    
    }

    private void RestoreRotation()
    {
        Vector3 originalRotation = new Quaternion(0, 0, 0, 1).eulerAngles;
        Vector3 currentRotation = planetrb.transform.rotation.eulerAngles;
        planetrb.transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}
