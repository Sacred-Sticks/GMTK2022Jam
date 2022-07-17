using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowRandom : MonoBehaviour
{
    [SerializeField] private Modifier modifier;
    [Space]
    [SerializeField] private GameObject inputManager;
    [SerializeField] private float randomRange;
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
    }

    private void FixedUpdate()
    {
        if (!thrown)
        {
            if ((firing > 0))
            {
                Throw();
                GetComponent<PlaceDice>().enabled = false;
                body.useGravity = true;
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
        body.velocity = Random.Range(1, randomRange) * transform.up + body.velocity;
        body.angularVelocity = (Random.Range(-randomRange, randomRange) * transform.up +
            Random.Range(-randomRange, randomRange) * transform.right +
            Random.Range(-randomRange, randomRange) * transform.forward) * angleMultiplier;
        thrown = true;
    }

    private IEnumerator GetWinner()
    {
        doneRolling = true;
        while (body.velocity.magnitude != 0)
        {
            yield return new WaitForFixedUpdate();
        }
        modifier.SetModifierValue(GetComponent<CalculateThrow>().CalculateValue());
        GetComponent<ShowButton>().EnableButton();
    }
}
