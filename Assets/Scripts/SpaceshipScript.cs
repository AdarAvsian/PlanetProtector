using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public Rigidbody2D spaceshiprb;
    public Rigidbody2D planetrb;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    public int moveSpeed = 700;
    public int grappleStrength = 2;

    private Vector2 planetPosition;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }


    private void FixedUpdate()
    {
        GrapplePlanet();
        MoveSpaceship();
    }

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spaceshiprb.AddForce(Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spaceshiprb.AddForce(Vector3.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spaceshiprb.AddForce(Vector3.down * moveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spaceshiprb.AddForce(Vector3.up * moveSpeed);
        }
    }

    private void GetPlanetPosition()
    {
        planetPosition = planetrb.transform.position;
    }

    private void GrapplePlanet()
    {
        GetPlanetPosition();
        
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
}
