using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowRandom : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;
    [SerializeField] private float randomRange;
    [SerializeField] private float waitTime;
    [SerializeField] private float sideMultiplier;
    [SerializeField] private float angleMultiplier;

    private PlayerInputs inputs;
    private Rigidbody body;

    private float firing;

    private bool thrown;
    private bool doneRolling = false;

    private void Awake()
    {
        inputs = inputManager.GetComponent<PlayerInputs>();
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        firing = inputs.GetFiring();
        if (transform.position.y > 25) body.velocity = new Vector3(body.velocity.x, body.velocity.y / 3, body.velocity.z);
    }

    private void FixedUpdate()
    {
        if (!thrown)
        {
            if ((firing > 0))
            {
                Throw();
            }
        }
        else
        {
            if (doneRolling) return;
            //Debug.Log("Checking Raycast");
            if (Physics.Raycast(transform.position, Vector3.down, .55f))
            {
                StartCoroutine(GetWinner());
            }
        }
    }

    private void Throw()
    {
        body.velocity = Random.Range(10, randomRange) * transform.up;
        body.angularVelocity = (Random.Range(-randomRange, randomRange) * transform.up +
            Random.Range(-randomRange, randomRange) * transform.right +
            Random.Range(-randomRange, randomRange) * transform.forward) * angleMultiplier;
        thrown = true;
    }

    private IEnumerator GetWinner()
    {
        doneRolling = true;
        while (body.velocity != Vector3.zero)
        {
            yield return new WaitForFixedUpdate();
        }
        Debug.Log(GetComponent<CalculateThrow>().CalculateValue() + " is the winning throw.");
    }
}
