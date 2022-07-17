using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealth : Modifier
{
    private Health health;
    private int modifierValue;

    public override void FindTarget()
    {
        health = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Health>();
    }

    public override void ModifyValue()
    {
        health.SetHealth(modifierValue);
    }

    public override void SetModifierValue(int modifierValue)
    {
        this.modifierValue = modifierValue;
    }

    public override int GetModifierValue()
    {
        return modifierValue;
    }
}
