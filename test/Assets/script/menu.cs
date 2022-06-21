using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public amulet amuletScript;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        Ending.End();
        amuletScript.Clean();
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
    {
        amuletScript.Clean();
        Application.Quit();
    }
}
