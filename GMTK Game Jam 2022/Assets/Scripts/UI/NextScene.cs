using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private SceneManagement sceneManager;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
        sceneIndex = sceneManager.GetSceneIndex() + 1;
    }

    public void NextLevel()
    {
        sceneManager.LoadScene(sceneIndex);
    }
}
