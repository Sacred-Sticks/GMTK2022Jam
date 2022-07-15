using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;
    [Space]
    [SerializeField] private float gracePeriod;
    [SerializeField] private float firerate;
    [SerializeField] private float clipSize;
    [SerializeField] private float reloadTime;

    private Quaternion direction;

    private IEnumerator Start()
    {
        float clip = clipSize;

        yield return new WaitForSeconds(gracePeriod);
        while (true)
        {
            SetRotation();
            Instantiate(bulletPrefab, transform);
            clip--;
            if (clip == 0)
            {
                yield return new WaitForSeconds(reloadTime);
                clip = clipSize;
            } else
            {
                yield return new WaitForSeconds(1.0f / firerate);
            }
        }
    }

    private void SetRotation()
    {
        if (target.position.x < transform.position.x) direction.eulerAngles = new Vector3(0, 180, 0);
        else direction.eulerAngles = Vector3.zero;
        transform.rotation = direction;
    }
}
