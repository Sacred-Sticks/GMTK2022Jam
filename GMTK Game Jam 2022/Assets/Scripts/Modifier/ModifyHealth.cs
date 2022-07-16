using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealth : Modifier
{
    [SerializeField] private string playerStr;

    private int modifierValue;

    private Health health;

    public override void FindTarget()
    {
        var player = GameObject.Find(playerStr);
        health = player.GetComponent<Health>();
    }

    public override void ModifyValue()
    {
        health.SetHealth(modifierValue);
        Debug.Log("Health Value Updated to " + modifierValue);
    }

    public override void SetModifierValue(int modifierValue)
    {
        this.modifierValue = modifierValue;
    }
}
