using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;
    [Space]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpWaitTime;
    [Space]
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;
    [Space]
    [SerializeField] private Transform lookAt;

    private Rigidbody body;

    private Vector2 movementInput;
    private Vector2 movement;

    bool isJumping = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementInput = inputs.GetMovement();
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        movement = (Vector3.right * movementInput.x * movementSpeed) + transform.up * body.velocity.y;
        body.velocity = movement;
        if (!(movementInput.y > 0)) return;
        if (CheckGround() && !isJumping) StartCoroutine("Jump");
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        if(lookAt == null)
            return;

        if (lookAt.position.x < transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private bool CheckGround()
    {
        return Physics.CheckSphere(feet.position, groundDistance, groundLayer);
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
        Vector3 jumpVelocity = body.velocity.x * transform.right + jumpSpeed * transform.up;
        body.velocity = jumpVelocity;
        yield return new WaitForSeconds(jumpWaitTime);
        isJumping = false;
    }

    public void SetMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
}
