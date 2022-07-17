using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private int controlsIndex;

    SceneManagement sceneManager;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
        Debug.Log("Scene Manager named " + sceneManager.name);
    }

    public void LoadLevel()
    {

        sceneManager.LoadScene(levelIndex);
    }

    public void LoadControls()
    {
        Debug.Log("Loading Controls");
        sceneManager.LoadScene(controlsIndex);
    }
}
