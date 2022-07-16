using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class DiceShotWhenUsingGravity : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float settleTime = 0.2f;
    [SerializeField] private float settleVelocity = 0.01f;
    [SerializeField] private int sides = 6;
    [SerializeField] private TextMeshPro rollResultText; 
    private float settleTimeRemaining;
    private readonly HashSet<GameObject> struckObjects = new();
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ResetTimeRemaining();
    }

    private void ResetTimeRemaining()
    {
        settleTimeRemaining = settleTime;
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude > settleVelocity)
        {
            ResetTimeRemaining();
            return;
        }

        settleTimeRemaining -= Time.fixedDeltaTime;
        if(settleTimeRemaining > 0f)
        {
            return;
        }

        ResolveRoll();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            struckObjects.Add(collision.gameObject);
        }
    }

    private void ResolveRoll()
    {
        int diceValue = Random.Range(1, sides + 1);
        foreach(GameObject obj in struckObjects)
        {
            Health health = obj.GetComponent<Health>();
            if(health != null)
            {
                health.ModifyHealth(-diceValue);
            }
        }

        TextMeshPro textInstance = Instantiate(rollResultText, transform.position + Vector3.up, Quaternion.identity);
        textInstance.text = diceValue.ToString();
        Destroy(gameObject);
    }
}
