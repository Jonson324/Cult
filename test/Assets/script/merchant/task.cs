using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task : MonoBehaviour {
    public inDialog inDialogScript;
    public dialog DialogScript;
    [HideInInspector] public bool quest;
    public GameObject quest_dialog;
    [HideInInspector] public bool quest_started;
    public GameObject ring;
    public GameObject thx;
    [HideInInspector] public bool thx1;
    public bool quest_completed;
    public GameObject current_task;
    public GameObject keep_search;
    [HideInInspector] public bool searching = false;
    public GameObject shop_doalog;
    public GameObject hint;
    public GameObject shop;
    public GameObject bye_dialog;
    [HideInInspector] public bool bye;
    [HideInInspector] public bool reply_No;
    public GameObject buttons;
    public GameObject talk;
    [HideInInspector] public bool talkin;
    int i = 0;

    public List<GameObject> quest_phrases = new List<GameObject>();
    public List<GameObject> shop_phrases = new List<GameObject>();
    
    void Update() {
        if (quest_started == true) {
            current_task.SetActive(true);
        } else {
            current_task.SetActive(false);
        }

        if (bye == true) {
            bye_dialog.SetActive(true);
        } else {
            bye_dialog.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialogScript.in_dialog == true) && (quest == true) && (quest_started == false) && (quest_completed == false)) {
            if (i != quest_phrases.Count - 1) {
                quest_phrases[i].SetActive(false);
                quest_phrases[i + 1].SetActive(true);
                i += 1;
            } else { quest_started = true; inDialogScript.in_dialog = false; quest_dialog.SetActive(false); ring.SetActive(true); }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (searching == true)) {
            keep_search.SetActive(false);
            searching = false;
            inDialogScript.in_dialog = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (thx1 == true)) {
            thx.SetActive(false);
            inDialogScript.in_dialog = false;
            thx1 = false;
            hint.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (bye == true)) {
            bye_dialog.SetActive(false);
            inDialogScript.in_dialog = false;
            bye = false;
            hint.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (reply_No == true)) {
            shop_doalog.SetActive(false);
            inDialogScript.in_dialog = false;
            shop_phrases[0].SetActive(true);
            buttons.SetActive(true);
            shop_phrases[1].SetActive(false);
            reply_No = false;
            hint.SetActive(true);
        }
    }

    void OnTriggerStay (Collider col) {
        if (col.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                hint.SetActive(false);
                inDialogScript.in_dialog = true;
                if (thx1 == true) {
                    thx.SetActive(true);
                } else if ((quest_started == true) && (quest_completed == false)) {
                    keep_search.SetActive(true);
                    searching = true;
                } else { 
                    if (quest_completed == false) {
                        quest = true;
                        quest_dialog.SetActive(true);
                    } else {
                        shop_doalog.SetActive(true);
                    }
                }
            }
        }
    }

    void OnTriggerEnter (Collider col) {
        if ((col.tag == "Player") && (quest_started == false)) {
            hint.SetActive(true);
        }
    }
    void OnTriggerExit (Collider col) {
        if (col.tag == "Player") {
            hint.SetActive(false);
        }
    }

    public void OpenShop() {
        shop_doalog.SetActive(false);
        shop.SetActive(true);
    }

    public void No() {
        shop_phrases[0].SetActive(false);
        buttons.SetActive(false);
        shop_phrases[1].SetActive(true);
        reply_No = true;
    }

    public void Talk() {
        shop_doalog.SetActive(false);
        DialogScript.first[0].SetActive(true);
        talk.SetActive(true);
        talkin = true;
        DialogScript.one = true;
    }
}