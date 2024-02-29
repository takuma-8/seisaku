using UnityEngine;
using UnityEngine.SceneManagement;

public class fsa : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}