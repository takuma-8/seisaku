using UnityEngine;
using UnityEngine.SceneManagement;

public class texBang: MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}