using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveX : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private float time;
    [SerializeField] bool moveLeft;

    private Rigidbody body;

    private Vector3 initialPos;
    float xPos;
    bool isMoving = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        initialPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (isMoving) return;
        if (moveLeft) StartCoroutine(Move(target.x, initialPos.x));
        else StartCoroutine(Move(initialPos.x, target.x));
    }

    private IEnumerator Move(float target, float start)
    {
        isMoving = true;
        float timePassed = 0;
        while (timePassed < time)
        {
            yield return new WaitForFixedUpdate();
            body.velocity = Vector3.left * (start - target)/time;
            timePassed += Time.fixedDeltaTime;
            //Debug.Log("Velocity Set to " + body.velocity);
        }
        //Reset Velocity to 0
        body.velocity = Vector3.zero;
        transform.position = new Vector3(target, transform.position.y, transform.position.z);
        //Debug.Log("Finished Moving");
        moveLeft = !moveLeft;
        isMoving = false;
    }
}
