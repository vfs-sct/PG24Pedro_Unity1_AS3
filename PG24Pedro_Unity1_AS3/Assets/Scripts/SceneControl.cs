using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] private GameManager _instance;
    public void LoadScene(string sceneName)
    {
        _instance.Restart();
        SceneManager.LoadScene(sceneName);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        _instance.Restart();
    }
}
