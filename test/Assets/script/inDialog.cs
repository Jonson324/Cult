using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inDialog : MonoBehaviour {
    public bool in_dialog;
    public GameObject health;
    public LevelHealth levelHealthScript;

    void Update() {
        if (in_dialog == true) {
            if (levelHealthScript.dead == false) {
                Time.timeScale = 0;
            }
            Cursor.lockState = CursorLockMode.None;
            health.SetActive(false);
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            health.SetActive(true);
        }
    }
}
