using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;
    [Space]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;

    private PlayerInputs inputs;
    private Rigidbody body;

    private Vector2 movementInput;
    private Vector2 movement;

    bool jumping = false;

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
        body.velocity = movement * movementSpeed;
        CalculateJump();
    }

    private void CalculateJump()
    {
        if (!(movementInput.y > 0)) return;

        float jumpForce = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y)/jumpTime;

        if (!jumping)
        {
            float jumpVelocity = jumpHeight * 2 / jumpTime;
            body.velocity = body.velocity.x * transform.right + jumpVelocity * transform.up;
            jumping = true;
            Debug.Log("Jumping with velocity " + body.velocity.y);
        }
    }
}
