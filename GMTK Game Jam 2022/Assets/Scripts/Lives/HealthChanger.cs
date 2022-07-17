using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private int modification;
    [SerializeField] private bool dontDestroy;
    [SerializeField] private float changeDelay;

    private Health health;
    private bool changing = false;

    private void OnCollisionEnter(Collision collision)
    {
        health = collision.gameObject.GetComponent<Health>();
        if (health == null) return;

        if (dontDestroy && !changing) StartCoroutine(DealDamage());
        else if (!dontDestroy)
        {
            health.ModifyHealth(modification);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        health = null;
    }

    private IEnumerator DealDamage()
    {
        changing = true;
        while (health != null)
        {
            health.ModifyHealth(modification);
            Debug.Log("Heyo");
            yield return new WaitForSeconds(changeDelay);
        }
        changing = false;
    }
}
