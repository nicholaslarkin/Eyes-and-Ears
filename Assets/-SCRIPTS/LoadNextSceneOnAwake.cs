using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnAwake : MonoBehaviour
{
    private void Awake()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            Debug.LogWarning("No next scene found in Build Settings!");
    }
}
