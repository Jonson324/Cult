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
        PlayerPrefs.DeleteKey("saveGame");
        PlayerPrefs.DeleteKey("jade");
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
