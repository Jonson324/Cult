using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour {
    public interact interactScript;
    private DataPlayer dataPlayer = new DataPlayer();

    [HideInInspector] public bool topic;
    public List<GameObject> topic_phrases = new List<GameObject>();

    [HideInInspector] public bool smith_douknow;
    [HideInInspector] public bool smith_knowledge;
    [HideInInspector] public bool smith_good_result;
    [HideInInspector] public bool smith_bad_result;
    public List<GameObject> douknow_phrases = new List<GameObject>();
    public List<GameObject> knowledge_phrases = new List<GameObject>();
    public List<GameObject> good_result_phrases = new List<GameObject>();
    public List<GameObject> bad_result_phrases = new List<GameObject>();
    int question = 0;
    public List<GameObject> q1_phrases = new List<GameObject>();
    public List<GameObject> q2_phrases = new List<GameObject>();
    public List<GameObject> q3_phrases = new List<GameObject>();

    [HideInInspector] public bool cult_fun;
    public List<GameObject> fun_phrases = new List<GameObject>();

    [HideInInspector] public bool cult_please;
    public List<GameObject> please_phrases = new List<GameObject>();

    [HideInInspector] public bool cult_details;
    public List<GameObject> details_phrases = new List<GameObject>();

    [HideInInspector] public bool cult_deal;
    public List<GameObject> deal_phrases = new List<GameObject>();

    public GameObject bye;
    [HideInInspector] public bool end;
    public static bool good;
    public static bool jade_only;
    int i = 0;
    public int score = 0;

    public class DataPlayer {
        public int jade_active = 0;
        public int jade_earned = 0;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (interactScript.talkin == true)) {
            if (topic == true) {
                Continue(topic_phrases, out topic);
            }

            if (smith_douknow == true) {
                Continue(douknow_phrases, out smith_douknow);
            }

            if (smith_knowledge == true) {
                Continue(knowledge_phrases, out smith_knowledge);
            }

            if (smith_good_result == true) {
                Continue(good_result_phrases, out smith_good_result);
            }

            if (smith_bad_result == true) {
                Continue(bad_result_phrases, out smith_bad_result);
            }

            if (cult_fun == true) {
                Continue(fun_phrases, out cult_fun);
            }

            if (cult_please == true) {
                Continue(please_phrases, out cult_please);
            }

            if (cult_details == true) {
                Continue(details_phrases, out cult_details);
            }

            if (cult_deal == true) {
                Continue(deal_phrases, out cult_deal);
            }

            if (end == true) {
                question = 0; score = 0;
                interactScript.talkin = false;
                interactScript.talk.SetActive(false);
                bye.SetActive(false);
                end = false;
                interactScript.welcome_dialog.SetActive(true);
            }
        }
    }

    bool Continue(List<GameObject> name, out bool num) {
        num = true;
        if (i != name.Count - 2) {
            name[i].SetActive(false);
            name[i + 1].SetActive(true);
            i++;
        } else { name[i + 1].SetActive(true); num = false; i = 0; }
        return num;
    }

    void Next(List<GameObject> prev, List<GameObject> next) {
        prev[prev.Count - 2].SetActive(false);
        prev[prev.Count - 1].SetActive(false);
        if (next != null) { 
            next[0].SetActive(true);
        }
        if ((question > 0) && (question < 4)) {
            next[1].SetActive(true);
        }
    }

    public void Smith() {
        smith_douknow = true;
        Next(topic_phrases, douknow_phrases);
    }

    public void Know() {
        question += 1;
        Next(douknow_phrases, q1_phrases);
    }

    public void DontKnow() {
        smith_knowledge = true;
        Next(douknow_phrases, knowledge_phrases);
    }

    public void Ready() {
        question += 1;
        Next(knowledge_phrases, q1_phrases);
    }

    void Answer() {
        question += 1;
        if (question == 2) {
            Next(q1_phrases, q2_phrases);
        }
        if (question == 3) {
            Next(q2_phrases, q3_phrases);
        }
        if ((question == 4) && (score == 3)) {
            Next(q3_phrases, good_result_phrases);
            smith_good_result = true;
            if (good == false) { amulet.free_points += 1; forge.price -= 100; good = true; }
            
        }
        if ((question == 4) && (score < 3)) {
            Next(q3_phrases, bad_result_phrases);
            smith_bad_result = true;
        }
    }

    public void Correct() {
        score += 1;
        Answer();
    }

    public void Wrong() {
        Answer();
    }

    public void Cult() {
        cult_fun = true;
        Next(topic_phrases, fun_phrases);
    }

    public void Fun() {
        cult_please = true;
        Next(fun_phrases, please_phrases);
    }

    public void Again() {
        cult_details = true;
        Next(please_phrases, details_phrases);
    }
    
    public void Deal() {
        cult_deal = true;
        Next(details_phrases, deal_phrases);
        if (jade_only == false) {
            jade_only = true;
            dataPlayer.jade_active = 1;
            PlayerPrefs.SetString("jade", JsonUtility.ToJson(dataPlayer));
        }
    }


    public void Bye() {
        Next(good_result_phrases, null);
        Next(bad_result_phrases, null);
        Next(deal_phrases, null);
        bye.SetActive(true);
        end = true;
    }
}
