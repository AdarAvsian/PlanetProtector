using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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

    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private InputActionReference grappleActionToUse;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    private void FixedUpdate()
    {
        GrapplePlanet();
        MoveSpaceship();

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
        }
    }

    private void MoveSpaceship()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        if (moveDirection != Vector2.zero)
        {
            handleGame();
        }
        spaceshiprb.AddForce(moveDirection * moveSpeed);
    }

    private void GrapplePlanet()
    {
        planetPosition = planetrb.transform.position;

        if (grappleActionToUse.action.IsPressed())
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
