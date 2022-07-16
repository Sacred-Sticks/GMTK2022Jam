using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private string targetStr;

    private Rigidbody body;
    private Transform target;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        target = GameObject.Find(targetStr).transform;
    }

    private void Start()
    {
        if (target.position.x > transform.position.x) 
            body.velocity = velocity;
        else body.velocity = -velocity;

        StartCoroutine(DeathCycle());
    }

    private IEnumerator DeathCycle()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
