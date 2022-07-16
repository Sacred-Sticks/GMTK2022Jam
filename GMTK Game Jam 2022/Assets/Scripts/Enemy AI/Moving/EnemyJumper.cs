using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyJumper : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float maxJumpSpeed;
    [Space]
    [SerializeField] private float lowWait;
    [SerializeField] private float highWait;
    [Space]
    [SerializeField] private Transform feet;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;

    private float jumpSpeed;
    private float jumpTime;
    private float moveSpeed;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private IEnumerator Start()
    {
        jumpSpeed = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
        jumpTime = 2 * -jumpSpeed / Physics.gravity.y;
        

        while (true)
        {
            //Break if target is dead
            if (target == null) break;

            //Set Rotation to face Target
            if (target.position.x < transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);
            else transform.rotation = Quaternion.Euler(0, 0, 0);

            //Wait to Jump
            yield return new WaitForSeconds(Random.Range(lowWait, highWait));
            if (target == null) break;
            while (!CheckGround()) yield return new WaitForFixedUpdate(); 
            Jump();

            //Wait for Landing
            yield return new WaitForSeconds(jumpTime);
            body.velocity = Vector3.zero;
            //Debug.Log("Landed");
        }
        Debug.Log("Broke from Jumping Loop");
    }
    private bool CheckGround()
    {
        return Physics.CheckSphere(feet.position, groundDistance, groundLayer);
    }

    private void Jump()
    {
        moveSpeed = Mathf.Abs(target.position.x - transform.position.x) / jumpTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 0, maxJumpSpeed);
        Vector3 jumpVelocity = moveSpeed * transform.right + jumpSpeed * transform.up;
        body.velocity = jumpVelocity;
    }
}
