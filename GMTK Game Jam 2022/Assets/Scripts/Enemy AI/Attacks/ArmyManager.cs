using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0162 // Unreachable code detected
public class ArmyManager : MonoBehaviour
{
    [SerializeField] private EnemyShooter[] army;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float gracePeriod;

    int random;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(gracePeriod);

        while (true)
        {
            random = Random.Range(0, army.Length);
            for (int i = 0; i < army.Length; i++)
            {
                if (random + i >= army.Length) random = -1;
                if (army[random + i] != null)
                {
                    StartCoroutine(army[random + i].Fire(timeBetweenShots));
                    yield return new WaitForSeconds(timeBetweenShots);
                    break;
                }
            }
        }
    }
}
#pragma warning restore CS0162 // Unreachable code detected
