using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;

    private Vector3 lookAt;

    private void Update()
    {
        //lookAt = transform.right * target.position.x + transform.up * target.position.y;
        //transform.LookAt(lookAt);


        float angle = Mathf.Atan2(target.position.x - transform.position.x, target.position.y - transform.position.y) * 180 / Mathf.PI;
        angle = -angle + offset;
        angle = Mathf.Clamp(angle, 135, 225);
        lookAt = Vector3.forward * angle;
        Debug.Log(lookAt);
        transform.rotation = Quaternion.Euler(lookAt);
    }
}
