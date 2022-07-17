using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowNewStat : MonoBehaviour
{
    [SerializeField] private Modifier modification;
    [SerializeField] private string mainMessage;

    private void Start()
    {
        GetComponent<TMP_Text>().text = mainMessage + modification.GetModifierValue();
    }
}
