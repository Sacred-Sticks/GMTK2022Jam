using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public void LoadScene(int nextScene)
    {
        SceneManager.LoadScene(nextScene);
        Debug.Log("Scene Changed");
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
