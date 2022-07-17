using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;
    [Space]
    [SerializeField] private float firerate;
    [SerializeField] private int clipSize;
    [Space]
    [SerializeField] private float angularOffset;

    private Quaternion direction;

    float timer;
    float angle;

    public IEnumerator Fire(float firingTime)
    {
        timer = 0;

        while (timer < firingTime)
        {
            SetRotation();
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            timer+= 1.0f / firerate;
                yield return new WaitForSeconds(1.0f / firerate);
        }
    }

    private void SetRotation()
    {
        if(target == null)
            return;

        if (target.position.x < transform.position.x) direction.eulerAngles = new Vector3(0, 180, 0);
        else direction.eulerAngles = Vector3.zero;
        transform.parent.parent.parent.rotation = direction;
    }
}
