using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName = "GamePlay";
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}