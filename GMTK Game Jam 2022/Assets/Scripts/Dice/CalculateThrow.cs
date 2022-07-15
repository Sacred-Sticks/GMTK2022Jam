using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateThrow : MonoBehaviour
{
    [SerializeField] private Transform[] sides;

    private Transform highestSide;
    public int CalculateValue()
    {
        for (int i = 0; i < sides.Length; i++)
        {
            if (highestSide == null) highestSide = sides[i];
            
            if (sides[i].position.y > highestSide.position.y) highestSide = sides[i];
        }
        int winningThrow;

        int.TryParse(highestSide.name, out winningThrow);
        return winningThrow;
    }
}
