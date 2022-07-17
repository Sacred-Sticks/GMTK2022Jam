using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetModifiers : MonoBehaviour
{
    private Modifier[] modifiers;

    void Start()
    {
        modifiers = FindObjectsOfType<Modifier>();
        for (int i = 0; i < modifiers.Length; i++)
        {
            modifiers[i].FindTarget();
            modifiers[i].ModifyValue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
