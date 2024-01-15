using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public Rigidbody2D spaceshiprb;
    public Rigidbody2D planet;
    public DistanceJoint2D distanceJoint2D;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    private Vector2 planetPosition;
    public Camera mainCamera;

    public int moveSpeed = 200;
    public int slowSpeed = 500;
    public float force = 2f;
    private Vector2 acceleration;
    private Vector2 lastVelocity;
    private float timer = 0;
    public float grappleSpeed;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }


    private void FixedUpdate()
    {
        GrapplePlanet();
        MoveSpaceship();
        acceleration = (spaceshiprb.velocity - lastVelocity);
        lastVelocity = spaceshiprb.velocity;
        if (acceleration.magnitude == 0 || acceleration.magnitude < 0)
        {
            spaceshiprb.AddForce(-lastVelocity * slowSpeed);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var direction = (planet.transform.position - (Vector3) spaceshiprb.position).normalized;
        planet.AddForce(direction * acceleration.magnitude, ForceMode2D.Impulse);
    }

    private void GetPlanetPosition()
    {
        planetPosition = planet.transform.position;
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

    private void GrapplePlanet()
    {
        GetPlanetPosition();
        if (lineRenderer.positionCount > 0)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, planetPosition);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            distanceJoint2D.enabled = true;
            var raycast = Physics2D.Raycast(mainCamera.transform.position, planetPosition, Mathf.Infinity, layerMask);
            lineRenderer.positionCount = 2;
            distanceJoint2D.connectedBody = raycast.rigidbody;
            distanceJoint2D.distance -= grappleSpeed;

        } else {
            lineRenderer.positionCount = 0;
            distanceJoint2D.enabled = false;
            print("working");
        }
        
    }
}
