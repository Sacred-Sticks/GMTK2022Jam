using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;

    private PlayerInputs inputs;
    private Rigidbody body;

    private Vector2 movementInput;
    private Vector2 movement;

    private void Awake()
    {
        inputs = inputManager.GetComponent<PlayerInputs>();
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementInput = inputs.GetMovement();
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        movement = transform.right * movementInput.x + transform.up * body.velocity.y;
        body.velocity = movement;
    }
}
