using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour {
    public GameObject first_dialog;
    bool first_end;
    bool inDialog;
    public GameObject welcome_dialog;
    bool welcome;
    public GameObject forge;
    public GameObject hint;

    void Update() {
        
    }

    void OnTriggerStay(Collider collider) {
        if (Input.GetKey(KeyCode.E)) {
            hint.SetActive(false);
            Time.timeScale = 0;
            if (first_end == false) {
                first_dialog.SetActive(true);
            } else {
                welcome_dialog.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            hint.SetActive(false);
        }
    }

    public void openForge() { 
        Time.timeScale = 0;
        forge.SetActive(true);
    }

    public void closeForge() {
        Time.timeScale = 1;
        forge.SetActive(false);
    }

    public void nextPhrase (GameObject phrase1, GameObject phrase2) {
        phrase1.SetActive(false);
        phrase2.SetActive(true);
    }
}
