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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameISPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        inDialogScript.in_dialog = false;
        //Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        //Time.timeScale = 1;
        GameISPause = false;
        //Cursor.visible = false;
    }
    public void Pause()
    {
        inDialogScript.in_dialog = true;
        //Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0;
        GameISPause = true;
        //Cursor.visible = true;
    }
    public void LoadMenu()
    {
        //Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(false);
        GameISPause = false;
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    } 
}
