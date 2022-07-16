using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    int currentScene;

    private void Start()
    {
        currentScene = 0;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentScene);
    }
}
