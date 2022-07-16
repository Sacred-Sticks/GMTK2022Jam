using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public SceneManagement Instance { get; private set; }

    int currentScene;

    private void Start()
    {
        instance = this;

        currentScene = 0;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentScene);
    }
}
