using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainProjectiles : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float projectileSpeed;
    [Space]
    [SerializeField] private float fireRate;
    [SerializeField] private float clipSize;
    [SerializeField] private float reloadTime;

    private Rigidbody body;

    float clip;
    bool isFiring = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isFiring) return;

        StartCoroutine(AttackCycle());
    }

    private IEnumerator AttackCycle()
    {
        isFiring = true;
        clip = clipSize;
        
        while (clip > 0)
        {
            Debug.Log("Clip Size:" + clip);
            Fire();
            if (clip > 0)
            {
                yield return new WaitForSeconds(1 / fireRate);
            } else
            {
                yield return new WaitForSeconds(reloadTime);
                clip = clipSize;
            }
        }
    }

    private void Fire()
    {
        clip--;
        foreach (var spawnpoint in spawnPoints)
        {
            var obj = Instantiate(projectiles[Random.Range(0, projectiles.Length)], spawnpoint.position, spawnpoint.rotation);
            obj.GetComponent<Rigidbody>().velocity = spawnpoint.right * projectileSpeed + body.velocity;
        }
    }
}
