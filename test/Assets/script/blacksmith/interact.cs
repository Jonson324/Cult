using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour {
    public inDialog inDialogScript;
    public talk talkScript;
    public GameObject smith_name;
    [HideInInspector] public bool first;
    public GameObject first_dialog;
    public GameObject quest_task;
    public GameObject hammer;
    public GameObject keep;
    public GameObject thx;
    [HideInInspector] public bool thx1;
    [HideInInspector] public bool quest_completed;
    [HideInInspector] public bool still;
    public bool start;
    public GameObject welcome_dialog;
    [HideInInspector] public bool welcome;
    public GameObject forge;
    public GameObject hint;
    [HideInInspector] public bool reply_No;
    public GameObject buttons;
    public GameObject bye_dialog;
    [HideInInspector] public bool bye;
    public GameObject talk;
    [HideInInspector] public bool talkin;
    int i = 0;

    public List<GameObject> first_phrases = new List<GameObject>();
    public List<GameObject> welcome_phrases = new List<GameObject>();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialogScript.in_dialog == true) && (start == true) && (first == true)) {
            if (i != first_phrases.Count - 1) {
                first_phrases[i].SetActive(false);
                first_phrases[i + 1].SetActive(true);
                i += 1;
            } else { start = false; first_dialog.SetActive(false); quest_task.SetActive(true); Off(); hammer.SetActive(true); }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (quest_completed == true) && (thx1 = true)) {
            quest_completed = false;
            thx1 = false;
            thx.SetActive(false);
            welcome_dialog.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (still == true)) {
            keep.SetActive(false);
            quest_task.SetActive(true);
            still = false;
            Off();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (reply_No == true)) {
            welcome_dialog.SetActive(false);
            welcome_phrases[0].SetActive(true);
            buttons.SetActive(true);
            welcome_phrases[1].SetActive(false);
            reply_No = false;
            Off();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (bye == true)) {
            bye_dialog.SetActive(false);
            bye = false;
            Off();
        }
    }

    void OnTriggerStay(Collider collider) {
        if (Input.GetKey(KeyCode.E)) {
            hint.SetActive(false);
            smith_name.SetActive(true);
            inDialogScript.in_dialog = true;
            if (start == true) {
                first = true;
                first_dialog.SetActive(true);
            }
            if ((start == false) && (first == true)) {
                keep.SetActive(true);
                still = true;
            }
            if (quest_completed == true) {
                thx.SetActive(true);
                thx1 = true;
            }
            if ((start == false) && (first == false) && (quest_completed == false)) {
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
        smith_name.SetActive(false);
        welcome_dialog.SetActive(false);
        forge.SetActive(true);
    }

    public void CloseForge() {
        forge.SetActive(false);
        bye_dialog.SetActive(true);
        smith_name.SetActive(true);
        bye = true;
    }

    public void No() {
        welcome_phrases[0].SetActive(false);
        buttons.SetActive(false);
        welcome_phrases[1].SetActive(true);
        reply_No = true;
    }

    public void Talk() {
        welcome_dialog.SetActive(false);
        talkScript.topic_phrases[0].SetActive(true);
        talk.SetActive(true);
        talkin = true;
        talkScript.topic = true;
    }

    void Off() {
        if (first == false) {
            hint.SetActive(true);
        }
        inDialogScript.in_dialog = false;
        smith_name.SetActive(false);
    }
}