using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    private int maxHealth;

    void Start()
    {
        maxHealth = health;
        UpdateText();
    }

    public void ModifyHealth(int modifier)
    {
        health += modifier;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateText();
        if (health <= 0) Destroy(this.gameObject);
    }

    public void SetHealth(int health)
    {
        this.health = Mathf.Clamp(health, 0, maxHealth);
        UpdateText();
    }

    public int GetHealth()
    {
        return health;
    }

    public void MaximizeHealth()
    {
        health = maxHealth;
        UpdateText();
    }

    private void UpdateText()
    {
        if(healthText == null)
            return;

        healthText.text = Mathf.Max(0, health).ToString();
    }
}
