using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour {
    public GameObject first_dialog;
    [HideInInspector] public bool start = true;
    [HideInInspector] public bool inDialog;
    public GameObject welcome_dialog;
    [HideInInspector] public bool welcome;
    public GameObject forge;
    public GameObject hint;
    [HideInInspector] public bool reply_No;
    public GameObject buttons;
    public GameObject bye_dialog;
    [HideInInspector] public bool bye;
    public GameObject health;
    int i = 0;

    public List<GameObject> first_phrases = new List<GameObject>();
    public List<GameObject> welcome_phrases = new List<GameObject>();

    void Update() {
        if (inDialog == true) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            health.SetActive(false);
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            health.SetActive(true);
        }

        if (start == false) { first_dialog.SetActive(false); }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialog == true) && (start == true)) {
            if (i != first_phrases.Count - 1) {
                first_phrases[i].SetActive(false);
                first_phrases[i + 1].SetActive(true);
                i += 1;
            } else { start = false; inDialog = false; }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (reply_No == true)) {
            welcome_dialog.SetActive(false);
            inDialog = false;
            welcome_phrases[0].SetActive(true);
            buttons.SetActive(true);
            welcome_phrases[1].SetActive(false);
            reply_No = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (bye == true))
        {
            bye_dialog.SetActive(false);
            inDialog = false;
            bye = false;
        }
    }

    void OnTriggerStay(Collider collider) {
        if (Input.GetKey(KeyCode.E)) {
            hint.SetActive(false);
            inDialog = true;
            if (start == true) {
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

    public void OpenForge() {
        welcome_dialog.SetActive(false);
        forge.SetActive(true);
    }

    public void CloseForge() {
        forge.SetActive(false);
        bye_dialog.SetActive(true);
        bye = true;
    }

    public void No() {
        welcome_phrases[0].SetActive(false);
        buttons.SetActive(false);
        welcome_phrases[1].SetActive(true);
        reply_No = true;
    }
}
