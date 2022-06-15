using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public amulet amuletScript;

    public void Play()
    {
        amuletScript.Clean();
        LevelHealth.levelHealth = 100;
        SceneManager.LoadScene(20);
    }

    public void Settings()
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
