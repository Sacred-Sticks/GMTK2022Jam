using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManager;
    [Space]
    [SerializeField] private int sceneIndex;

    public void NextLevel()
    {
        sceneManager.LoadScene(sceneIndex);
    }
}
