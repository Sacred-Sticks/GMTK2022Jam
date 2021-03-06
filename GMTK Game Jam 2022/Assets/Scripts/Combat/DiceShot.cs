using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class DiceShot : MonoBehaviour
{
    public int Damage { get; set; } = 3;
    [SerializeField] private string targetTag;
    [SerializeField] private TextMeshPro rollResultText; 

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag(targetTag))
            Destroy(gameObject);

        Health health = collision.gameObject.GetComponent<Health>();
        if (health == null)
        {
            Destroy(gameObject);
            return;
        }

        health.ModifyHealth(-Damage);

        TextMeshPro textInstance = Instantiate(rollResultText, transform.position + Vector3.up + Vector3.forward * -10, Quaternion.identity);
        textInstance.text = Damage.ToString();
        Destroy(gameObject);
    }
}
