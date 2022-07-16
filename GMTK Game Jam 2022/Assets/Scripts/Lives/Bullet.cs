using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private IEnumerator Start()
    {
        body.velocity = speed * transform.right;

        //Remove any parental relationship
        transform.parent = null;

        //Destroy bullet after timer
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
