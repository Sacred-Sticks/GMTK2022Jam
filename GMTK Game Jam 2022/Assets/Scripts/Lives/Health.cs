using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private bool isPlayer;

    void Start()
    {
        UpdateText();
    }

    public void ModifyHealth(int modifier)
    {
        health += modifier;
        UpdateText();
        SceneManagement sceneManager = FindObjectOfType<SceneManagement>();
        if (health > 0) return;
        if (isPlayer) sceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

    public void SetHealth(int health)
    {
        this.health = health;
        UpdateText();
    }

    public int GetHealth()
    {
        return health;
    }

    private void UpdateText()
    {
        if(healthText == null)
            return;

        healthText.text = Mathf.Max(0, health).ToString();
    }
}
