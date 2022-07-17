using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void NextLevel()
    {
        FindObjectOfType<SceneManagement>().LoadScene(sceneIndex);
    }
}
