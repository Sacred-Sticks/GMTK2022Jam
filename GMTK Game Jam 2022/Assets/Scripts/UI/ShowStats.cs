using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowStats : MonoBehaviour
{
    [SerializeField] private int[] defaultValues;

    private Modifier[] modifications;

    private void Awake()
    {
        modifications = new Modifier[defaultValues.Length];
        modifications[0] = FindObjectOfType<ModifyHealth>();
        modifications[1] = FindObjectOfType<ModifyMoveSpeed>();
        modifications[2] = FindObjectOfType<ModifyDamage>();
    }

    private void Start()
    {
        int[] numbers = new int[defaultValues.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (modifications[i] != null)
            {
                if (i == 2)
                    Debug.Log("Hi");
                numbers[i] = modifications[i].GetModifierValue();
            } else
            {
                numbers[i] = defaultValues[i];
            }
        }

        GetComponent<TMP_Text>().text = $"Health: {numbers[0]}\nMovement-Speed: {numbers[1]}\nDamage: {numbers[2]}";
    }
}
