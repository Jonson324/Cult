using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour {
    public inDialog inDialogScript;
    public talk talkScript;
    private DataPlayer dataPlayer = new DataPlayer();

    public AudioSource hammer_down;

    public GameObject smith_name;
    public static bool start = true;
    public static bool first;
    public static bool quest_completed;

    public GameObject first_dialog;
    public GameObject quest_task;
    public GameObject hammer;
    public GameObject keep;
    public GameObject thx;
    [HideInInspector] public bool thx1;
    [HideInInspector] public bool still;
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

    public GameObject uIdiot;
    [HideInInspector] public bool idiot;

    public GameObject jadeBtn;
    public GameObject jade_dialog;
    [HideInInspector] public bool jade1;
    [HideInInspector] public bool jade2;
    int i = 0;

    public List<GameObject> first_phrases = new List<GameObject>();
    public List<GameObject> welcome_phrases = new List<GameObject>();
    public List<GameObject> jade_phrases1 = new List<GameObject>();
    public List<GameObject> jade_phrases2 = new List<GameObject>();

    public class DataPlayer {
        public int jade_active = 0;
        public int jade_earned = 0;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialogScript.in_dialog == true) && (start == true) && (first == true)) {
            if (i != first_phrases.Count - 1) {
                first_phrases[i].SetActive(false);
                first_phrases[i + 1].SetActive(true);
                i += 1;
            } else { start = false; first_dialog.SetActive(false); quest_task.SetActive(true); Off(); hammer.SetActive(true); i = 0; }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (quest_completed == true) && (thx1 == true)) {
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && (jade1 == true)) {
            if (i != jade_phrases1.Count - 2) {
                if (i == 1) { jade_dialog.SetActive(false); smith_name.SetActive(false); }
                if (i == 2) { jade_dialog.SetActive(true); smith_name.SetActive(true); }
                jade_phrases1[i].SetActive(false);
                jade_phrases1[i + 1].SetActive(true);
                i += 1;
            } else { jade_phrases1[i + 1].SetActive(true); jade1 = false; }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (jade2 == true)) {
            if (i != jade_phrases2.Count - 1) {
                if (i == 1) { jade_dialog.SetActive(false); smith_name.SetActive(false); }
                jade_phrases2[i].SetActive(false);
                jade_phrases2[i + 1].SetActive(true);
                i += 1;
            } else { jade2 = false; Off();
                foreach (var phr in jade_phrases2) { phr.SetActive(false); }
                dataPlayer.jade_earned = 0;
                PlayerPrefs.SetString("jade", JsonUtility.ToJson(dataPlayer));
                LevelHealth.maxhealth += 10;
                LevelHealth.levelHealth += 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (idiot == true)) {
            uIdiot.SetActive(false);
            idiot = false;
            Off();
        }
    }

    void OnTriggerStay(Collider collider) {
        if ((collider.tag == "Player") && (task.quest_started == false)) {
            if (Input.GetKey(KeyCode.E)) {
                JadeCheck();
                hint.SetActive(false);
                smith_name.SetActive(true);
                inDialogScript.in_dialog = true;
                if (amulet.hammer_found == true) {
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
                        hammer_down.Play();
                    }
                }
                else {
                    uIdiot.SetActive(true);
                    idiot = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider) {
        if ((collider.tag == "Player") && (task.quest_started == false) && (first == false)) {
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

    void JadeCheck() {
        if (PlayerPrefs.HasKey("jade")) {
            dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("jade"));
        } else {
            PlayerPrefs.SetString("jade", JsonUtility.ToJson(dataPlayer));
        }
        if (dataPlayer.jade_earned == 1) { jadeBtn.SetActive(true); talkScript.jadeQuestButton.SetActive(false); }
        if (dataPlayer.jade_earned == 0) { jadeBtn.SetActive(false); }
        if (dataPlayer.jade_active == 1) { talkScript.jadeQuestButton.SetActive(false); }
    }

    public void Jade() {
        welcome_dialog.SetActive(false);
        jade_dialog.SetActive(true);
        jade1 = true;
    }

    public void JadeOk() {
        foreach (var phr in jade_phrases1) { phr.SetActive(false); }
        jade_phrases2[0].SetActive(true);
        i = 0;
        jade2 = true;
    }
}