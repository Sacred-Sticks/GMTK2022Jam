using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyJumper : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Space]
    [SerializeField] private float jumpDistanceLow;
    [SerializeField] private float jumpDistanceHigh;
    [SerializeField] private float jumpHeight;
    [Space]
    [SerializeField] private float lowWait;
    [SerializeField] private float highWait;

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
            yield return new WaitForSeconds(Random.Range(lowWait, highWait));
            yield return new WaitForFixedUpdate();
            Jump();
            yield return new WaitForSeconds(jumpTime);
            Debug.Log("Landed");
        }
    }

    private void Jump()
    {
        moveSpeed = target.position.x - transform.position.x / jumpTime;
        Vector3 jumpVelocity = moveSpeed * transform.right + jumpSpeed * transform.up;
        body.velocity = jumpVelocity;
    }
}
