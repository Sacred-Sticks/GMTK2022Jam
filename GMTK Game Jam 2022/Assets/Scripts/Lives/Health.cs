using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;

    void Start()
    {
        UpdateText();
    }

    public void ModifyHealth(int modifier)
    {
        health += modifier;
        UpdateText();
        if (health <= 0) Destroy(this.gameObject);
    }

    public void SetHealth(int health)
    {
        this.health = health;
        UpdateText();
    }

    private void UpdateText()
    {
        if(healthText == null)
            return;

        healthText.text = Mathf.Max(0, health).ToString();
    }
}
