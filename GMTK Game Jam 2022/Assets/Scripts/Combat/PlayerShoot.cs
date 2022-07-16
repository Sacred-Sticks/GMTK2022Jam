using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float velocity = 4f;
    [SerializeField] private float firingDelay = 0.5f;
    private float firingDelayRemaining = 0f;

    void Update()
    {
        firingDelayRemaining = Mathf.Max(0f, firingDelayRemaining - Time.deltaTime);

        if(inputs.GetFiring() > 0f && firingDelayRemaining == 0f)
        {
            GameObject obj = Instantiate(projectile, muzzle.position, muzzle.rotation);
            obj.GetComponent<Rigidbody>().velocity = obj.transform.right * velocity;
            firingDelayRemaining += firingDelay;
        }
    }
}
