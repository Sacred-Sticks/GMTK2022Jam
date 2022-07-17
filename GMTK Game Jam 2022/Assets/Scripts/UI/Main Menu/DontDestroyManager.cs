using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
    [SerializeField] GameObject[] dontDestroys;

    private void Awake()
    {
        dontDestroys = GameObject.FindGameObjectsWithTag("DontDestroy");
        DestroyObjects();
    }

    private void DestroyObjects()
    {
        foreach (var dontDestroy in dontDestroys)
        {
            if (dontDestroy.name != "Level Manager")
                Destroy(dontDestroy);
        }
    }
}
