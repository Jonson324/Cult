using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    public LevelHealth lvlHealth;
    public void Play()
    {
        lvlHealth.start = true;
        SceneManager.LoadScene(1);
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
