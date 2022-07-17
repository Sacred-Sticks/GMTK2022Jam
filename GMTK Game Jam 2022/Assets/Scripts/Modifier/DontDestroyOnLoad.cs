using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private string objName;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        objName = gameObject.name;
        GameObject[] dontDestroy = GameObject.FindGameObjectsWithTag("DontDestroy");
        foreach (GameObject go in dontDestroy)
        {
            if (go == this.gameObject) return;

            if (go.name == objName) Destroy(this.gameObject);
        }
    }
}
