using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float forwardsOffset;
    [SerializeField] private float lowClamp;
    [SerializeField] private float highClamp;

    private Vector3 lookAt;
    float angle;

    private void Update()
    {
        angle = Mathf.Atan2(target.position.x - transform.position.x, target.position.y - transform.position.y) * 180 / Mathf.PI;
        angle += 90;
        if (transform.position.x < target.position.x)
        {
            angle = angle + forwardsOffset;
            Debug.Log("Rotation Needed Update");
        }
        if (angle > 180) angle -= 360;
        angle = Mathf.Clamp(angle, lowClamp, highClamp);
        angle = -angle;
        lookAt = transform.forward * angle;
        transform.localRotation = Quaternion.Euler(lookAt);
}
}
