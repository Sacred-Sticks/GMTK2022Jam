using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    public abstract void FindTarget();

    public abstract void ModifyValue();

    public abstract void SetModifierValue(int modifierValue);
}
