using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task : MonoBehaviour {
    private DataPlayer dataPlayer = new DataPlayer();
    public inDialog inDialogScript;
    public dialog DialogScript;
    public PauseMenu pauseMenuScript;
    public amulet amuletScript;

    public GameObject merch_name;
    [HideInInspector] public bool quest;
    public GameObject quest_dialog;
    [HideInInspector] public static bool quest_started;
    public GameObject ring;
    public GameObject thx;
    [HideInInspector] public bool thx1;
    public static bool quest_completed;
    public GameObject current_task;
    public GameObject keep_search;
    [HideInInspector] public bool searching = false;

    public GameObject shop_dialog;
    public GameObject hint;
    public GameObject shop;
    public GameObject bye_dialog;
    [HideInInspector] public bool bye;
    [HideInInspector] public bool reply_No;
    public GameObject buttons;
    public GameObject talk;
    [HideInInspector] public bool talkin;
    [HideInInspector] public bool secretScroll;
    [HideInInspector] public bool secretScrollNo;
    [HideInInspector] public bool secretScrollYes;
    public GameObject scroll_dialog;
    public GameObject scrollBtn;
    public Text money_txt;
    public GameObject money_obj;
    public GameObject message;
    int i = 0;

    public List<GameObject> quest_phrases = new List<GameObject>();
    public List<GameObject> shop_phrases = new List<GameObject>();
    public List<GameObject> scroll_phrases = new List<GameObject>();
    public List<GameObject> scrollButtons = new List<GameObject>();

    public AudioSource shop_open;

    public class DataPlayer {
        public int money;
        public List<string> buyItem = new List<string>();
    }

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

        if ((inDialogScript.in_dialog == true) && (pauseMenuScript.GameISPause == false)) {
            if (Input.GetKeyDown(KeyCode.Mouse0) && (quest == true) && (quest_started == false) && (quest_completed == false)) {
                if (i != quest_phrases.Count - 1) {
                    quest_phrases[i].SetActive(false);
                    quest_phrases[i + 1].SetActive(true);
                    i += 1;
                } else { quest_started = true; inDialogScript.in_dialog = false; quest_dialog.SetActive(false); ring.SetActive(true); merch_name.SetActive(false); i = 0; }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (searching == true)) {
                keep_search.SetActive(false);
                searching = false;
                merch_name.SetActive(false);
                inDialogScript.in_dialog = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (thx1 == true)) {
                thx.SetActive(false);
                inDialogScript.in_dialog = false;
                thx1 = false;
                merch_name.SetActive(false);
                hint.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (bye == true)) {
                bye_dialog.SetActive(false);
                inDialogScript.in_dialog = false;
                bye = false;
                merch_name.SetActive(false);
                hint.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (reply_No == true)) {
                shop_dialog.SetActive(false);
                inDialogScript.in_dialog = false;
                shop_phrases[0].SetActive(true);
                buttons.SetActive(true);
                shop_phrases[1].SetActive(false);
                reply_No = false;
                merch_name.SetActive(false);
                hint.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (secretScroll == true)) {
                money_obj.SetActive(true);
                if (dataPlayer.money > 5000) {
                    scrollButtons[0].SetActive(true);
                    scrollButtons[1].SetActive(true);
                }
                if (dataPlayer.money < 5000) {
                    scrollButtons[2].SetActive(true);
                }
                secretScroll = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (secretScrollNo == true)) {
                ScrollHide();
                message.SetActive(false);
                merch_name.SetActive(true);
                shop_dialog.SetActive(true);
                secretScrollNo = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (secretScrollYes == true)) {
                ScrollHide();
                merch_name.SetActive(false);
                message.SetActive(true);
                secretScrollYes = false;
                secretScrollNo = true;
            }
        }
    }

    void OnTriggerStay (Collider col) {
        if (col.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                hint.SetActive(false);
                merch_name.SetActive(true);
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
                        shop_dialog.SetActive(true);
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
        merch_name.SetActive(false);
        shop_dialog.SetActive(false);
        shop.SetActive(true);
        shop_open.Play();
    }

    public void No() {
        shop_phrases[0].SetActive(false);
        buttons.SetActive(false);
        shop_phrases[1].SetActive(true);
        reply_No = true;
    }

    public void Talk() {
        shop_dialog.SetActive(false);
        DialogScript.first[0].SetActive(true);
        talk.SetActive(true);
        talkin = true;
        DialogScript.one = true;
    }

    public void objectFound() {
        quest_started = false;
        quest_completed = true;
    }

    public void Scroll() {
        shop_dialog.SetActive(false);
        scroll_dialog.SetActive(true);
        secretScroll = true;
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("saveGame"));
        money_txt.text = "На счету: " + dataPlayer.money;
    }

    public void ScrollBuy() {
        dataPlayer.money -= 5000;
        PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(dataPlayer));
        scrollBtn.SetActive(false);
        amuletScript.ScrollActivate();
        ScrollEnd();
        scroll_phrases[1].SetActive(true);
        secretScrollYes = true;
    }

    public void ScrollDeny() {
        ScrollEnd();
        scroll_phrases[2].SetActive(true);
        secretScrollNo = true;
    }

    public void ScrollNoMoney() {
        ScrollEnd();
        scroll_phrases[3].SetActive(true);
        secretScrollNo = true;
    }

    void ScrollEnd() {
        foreach (var btn in scrollButtons) { btn.SetActive(false); }
        money_obj.SetActive(false);
        scroll_phrases[0].SetActive(false);
    }

    void ScrollHide() {
        foreach (var phr in scroll_phrases) { phr.SetActive(false); }
        scroll_dialog.SetActive(false);
        scroll_phrases[0].SetActive(true);
    }
}