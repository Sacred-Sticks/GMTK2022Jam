using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;
    [SerializeField] private Transform muzzle;
    [SerializeField] private DiceShot diceShot;
    [SerializeField] private float velocity = 4f;
    [SerializeField] private float firingDelay = 0.5f;
    private float firingDelayRemaining = 0f;

    public DiceShot GetDiceShot()
    {
        return diceShot;
    }

    void Update()
    {
        firingDelayRemaining = Mathf.Max(0f, firingDelayRemaining - Time.deltaTime);

        if(inputs.GetFiring() > 0f && firingDelayRemaining == 0f)
        {
            DiceShot instance = Instantiate(diceShot, muzzle.position, muzzle.rotation);
            instance.GetComponent<Rigidbody>().velocity = instance.gameObject.transform.right * velocity;
            firingDelayRemaining += firingDelay;
        }
    }
}
