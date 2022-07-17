using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void EnableButton()
    {
        button.SetActive(true);
    }
}
