using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyMoveSpeed : Modifier
{
    private PlayerMovement movement;

    private int modifierValue;

    public override void FindTarget()
    {
        var player = GameObject.Find("Player");
        movement = player.GetComponent<PlayerMovement>();
    }

    public override void ModifyValue()
    {
        movement.SetMovementSpeed(modifierValue);
        Debug.Log("Movement Speed Updated to " + modifierValue);
    }

    public override void SetModifierValue(int modifierValue)
    {
        this.modifierValue = modifierValue;
    }
}