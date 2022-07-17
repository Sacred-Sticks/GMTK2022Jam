using UnityEngine;

public class ModifyDamage : Modifier
{
    private DiceShot diceShot;
    private int modifierValue;

    public override void FindTarget()
    {
        diceShot = FindObjectOfType<PlayerShoot>().GetDiceShot();
    }

    public override void ModifyValue()
    {
        diceShot.Damage = modifierValue;
    }

    public override void SetModifierValue(int modifierValue)
    {
        this.modifierValue = modifierValue;
    }
}
