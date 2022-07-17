using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class DiceShotWithRandomDamage : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private int sides = 6;
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

        int diceValue = Random.Range(1, sides + 1);
        health.ModifyHealth(-diceValue);

        TextMeshPro textInstance = Instantiate(rollResultText, transform.position + Vector3.up + Vector3.forward * -10, Quaternion.identity);
        textInstance.text = diceValue.ToString();
        Destroy(gameObject);
    }
}
