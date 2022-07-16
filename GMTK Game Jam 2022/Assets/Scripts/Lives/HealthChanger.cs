using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private int modification;

    private Health health;

    private void OnCollisionEnter(Collision collision)
    {
        health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ModifyHealth(modification);
        }
        Destroy(this.gameObject);
    }
}
