using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] private string message;
    private TMP_Text text;

    private int health;
    private Health healthObj;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        healthObj = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        health = healthObj.GetHealth();
        text.text = $"Health: {health}";
    }
}
