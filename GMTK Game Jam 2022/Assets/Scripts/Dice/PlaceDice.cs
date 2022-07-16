using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDice : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;
    [SerializeField] private float speed;

    private Rigidbody body;

    private Vector2 movementInput;
    private Vector3 movement;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        movementInput = inputs.GetMovement();
    }

    private void Move()
    {
        movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;
        body.velocity = movement;
    }
}
