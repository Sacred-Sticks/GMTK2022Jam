using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDice : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;

    private Vector2 movementInput;

    private void GetInput()
    {
        movementInput = inputs.GetMovement();
    }

    private void Move()
    {
        
    }
}
