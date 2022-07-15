using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;
    [Space]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpWaitTime;
    [Space]
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;

    private PlayerInputs inputs;
    private Rigidbody body;

    private Vector2 movementInput;
    private Vector2 movement;

    [SerializeField] bool isJumping = false;

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
        movement = (transform.right * movementInput.x * movementSpeed) + transform.up * body.velocity.y;
        body.velocity = movement;
        if (!(movementInput.y > 0)) return;
        if (CheckGround() && !isJumping) StartCoroutine("Jump");
    }

    private bool CheckGround()
    {
        return Physics.CheckSphere(feet.position, groundDistance, groundLayer);
    }

    private void CalculateJump()
    {
        if (!(movementInput.y > 0)) return;

        if (!isJumping)
        {
            float jumpVelocity = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
            Vector3 jumpVelocityV3 = body.velocity.x * transform.right + jumpVelocity * transform.up;
            Debug.Log(jumpVelocity);
            body.velocity = jumpVelocityV3;
            isJumping = true;
            Debug.Log("Jumping with velocity " + body.velocity.y);
        }
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
        Vector3 jumpVelocityV3 = body.velocity.x * transform.right + jumpSpeed * transform.up;
        body.velocity = jumpVelocityV3;
        yield return new WaitForSeconds(jumpWaitTime);
        isJumping = false;
    }
}
