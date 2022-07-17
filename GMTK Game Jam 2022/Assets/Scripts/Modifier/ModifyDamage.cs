using UnityEngine;

public class ModifyDamage : Modifier
{
    private PlayerShoot playerShoot;
    private int modifierValue;

    public override void FindTarget()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
    }

    public override void ModifyValue()
    {
        playerShoot.SetDamage(modifierValue);
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
