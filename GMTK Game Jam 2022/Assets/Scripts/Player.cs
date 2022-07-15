using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputs playerInputs;
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 movement = playerInputs.GetMovement();
        //rb.AddForce(movement * speed);
        rb.AddForce(new Vector3(movement.x * 10f, 0, 0));
    }
}
