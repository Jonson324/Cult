using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inDialog : MonoBehaviour {
    public bool in_dialog;
    public GameObject health;

    void Update() {
        if (in_dialog == true) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            health.SetActive(false);
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            health.SetActive(true);
        }
    }
}
