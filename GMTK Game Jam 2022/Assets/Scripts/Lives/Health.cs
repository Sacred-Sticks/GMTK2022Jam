using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    
    public void ModifyHealth(int modifier)
    {
        health += modifier;
        if (health < 0) Destroy(this.gameObject);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
