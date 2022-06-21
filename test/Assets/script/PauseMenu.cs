using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool GameISPause = false;
    public GameObject pauseMenuUI;
    public inDialog inDialogScript;
    public LevelHealth levelHealthScript;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (levelHealthScript.dead == false) && (Ending.end == false))
        {
            if (GameISPause)
            {
                Resume();
            }
            else if ((GameISPause == false) && (inDialogScript.in_dialog == false))
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        inDialogScript.in_dialog = false;
        pauseMenuUI.SetActive(false);
        GameISPause = false;
    }

    public void Pause()
    {
        inDialogScript.in_dialog = true;
        pauseMenuUI.SetActive(true);
        GameISPause = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        GameISPause = false;
        SceneManager.LoadScene(0);
    } 
}
