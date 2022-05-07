using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour {
    public inDialog inDialogScript;
    [HideInInspector] public bool first;
    public GameObject first_dialog;
    [HideInInspector] public bool start = true;
    public GameObject welcome_dialog;
    [HideInInspector] public bool welcome;
    public GameObject forge;
    public GameObject hint;
    [HideInInspector] public bool reply_No;
    public GameObject buttons;
    public GameObject bye_dialog;
    [HideInInspector] public bool bye;
    int i = 0;

    public List<GameObject> first_phrases = new List<GameObject>();
    public List<GameObject> welcome_phrases = new List<GameObject>();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialogScript.in_dialog == true) && (start == true) && (first == true)) {
            if (i != first_phrases.Count - 1) {
                first_phrases[i].SetActive(false);
                first_phrases[i + 1].SetActive(true);
                i += 1;
            } else { start = false; inDialogScript.in_dialog = false; first_dialog.SetActive(false); hint.SetActive(true); }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (reply_No == true)) {
            welcome_dialog.SetActive(false);
            inDialogScript.in_dialog = false;
            welcome_phrases[0].SetActive(true);
            buttons.SetActive(true);
            welcome_phrases[1].SetActive(false);
            reply_No = false;
            hint.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (bye == true)) {
            bye_dialog.SetActive(false);
            inDialogScript.in_dialog = false;
            bye = false;
            hint.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collider) {
        if (Input.GetKey(KeyCode.E)) {
            hint.SetActive(false);
            inDialogScript.in_dialog = true;
            if (start == true) {
                first = true;
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