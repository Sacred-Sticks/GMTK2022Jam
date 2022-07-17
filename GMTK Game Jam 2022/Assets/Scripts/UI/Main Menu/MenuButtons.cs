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
    }

    public void LoadLevel()
    {

        sceneManager.LoadScene(levelIndex);
    }

    public void LoadControls()
    {
        sceneManager.LoadScene(controlsIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
