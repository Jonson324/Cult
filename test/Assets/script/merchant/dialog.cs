using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour {
    public task taskScript;
    public shop shopScript;
    
    [HideInInspector] public bool one;
    public List<GameObject> first = new List<GameObject>();

    [HideInInspector] public bool two;
    public List<GameObject> second = new List<GameObject>();

    [HideInInspector] public bool three;
    [HideInInspector] public bool three_end;
    public List<GameObject> third = new List<GameObject>();
    public List<GameObject> third_end = new List<GameObject>();

    [HideInInspector] public bool four;
    [HideInInspector] public bool four_about;
    [HideInInspector] public bool four_rusure;
    [HideInInspector] public bool four_onlyone;
    [HideInInspector] public bool four_how;
    [HideInInspector] public bool four_noq;
    public List<GameObject> fourth = new List<GameObject>();
    public List<GameObject> fourth_about = new List<GameObject>();
    public List<GameObject> fourth_rusure = new List<GameObject>();
    public List<GameObject> fourth_onlyone = new List<GameObject>();
    public List<GameObject> fourth_how = new List<GameObject>();
    public List<GameObject> fourth_noq = new List<GameObject>();

    public List<Button> buttonsInteract = new List<Button>();
    public List<GameObject> buttonsActive = new List<GameObject>();

    public GameObject bye;
    [HideInInspector] public bool end;
    int i = 0;
    int j = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (taskScript.talkin == true)) {
            if (one == true) {
                ContinueBtn(first, out one);
            }

            if (two == true) {
                ContinueBtn(second, out two);
            }

            if (three == true) {
                ContinueBtn(third, out three);
            }

            if (three_end == true) {
                if (i != third_end.Count - 1) {
                    third_end[i].SetActive(false);
                    third_end[i + 1].SetActive(true);
                    i++;
                } else { three_end = false; i = 0; Next(third_end, null); end = true; }
            }

            if (four == true) {
                ContinueBtn(fourth, out four);
            }

            if (four_about == true) {
                ContinueNoBtn(fourth_about, out four_about);
            }

            if (four_rusure == true) {
                ContinueNoBtn(fourth_rusure, out four_rusure);
            }

            if (four_onlyone == true) {
                ContinueNoBtn(fourth_onlyone, out four_onlyone);
            }

            if (four_how == true) {
                ContinueNoBtn(fourth_how, out four_how);
            }

            if (four_noq == true) {
                if (i != fourth_noq.Count - 1) {
                    fourth_noq[i].SetActive(false);
                    fourth_noq[i + 1].SetActive(true);
                    i++;
                } else { 
                    four_noq = false; i = 0; j = 0;
                    Next(fourth_noq, null);
                    foreach (var button in buttonsInteract) { button.interactable = true; }
                    foreach (var button in buttonsActive) { button.SetActive(true); }
                    buttonsActive[4].SetActive(false);
                    end = true;
                }
            }

            if (end == true) {
                taskScript.talkin = false;
                taskScript.talk.SetActive(false);
                bye.SetActive(false);
                end = false;
                taskScript.shop_doalog.SetActive(true);
            }
        }
    }

    bool ContinueBtn(List<GameObject> name, out bool num) {
        num = true;
        if (i != name.Count - 2) {
            name[i].SetActive(false);
            name[i + 1].SetActive(true);
            i++;
        } else { name[i + 1].SetActive(true); num = false; i = 0; }
        return num;
    }

    bool ContinueNoBtn(List<GameObject> name, out bool num) {
        num = true;
        if (i != name.Count - 1) {
            name[i].SetActive(false);
            name[i + 1].SetActive(true);
            i++;
        } else { name[i].SetActive(false); num = false; i = 0; four = true; fourth[0].SetActive(true); }
        return num;
    }

    void Next(List<GameObject> prev, List<GameObject> next) {
        prev[prev.Count - 2].SetActive(false);
        prev[prev.Count - 1].SetActive(false);
        if (next != null) { 
            next[0].SetActive(true);
        }
    }

    void ButtonOff(List<Button> buttons, int k) {
        buttons[k].interactable = false;
        j += 1;
    }

    void ButtonShow() { 
        if (j == 4) {
            foreach (var button in buttonsActive) { button.SetActive(false); }
            buttonsActive[4].SetActive(true);
        }
    }

    public void Yes() {
        two = true;
        Next(first, second);
    }

    public void Unbelivable() {
        three = true;
        Next(second, third);
    }

    public void IWill() {
        Next(third, null);
        three = false;
        three_end = true;
        third_end[0].SetActive(true);
    }

    public void Questions() {
        four = true;
        Next(second, fourth);
    }

    public void About() {
        four = false;
        four_about = true;
        Next(fourth, fourth_about);
        ButtonOff(buttonsInteract, 0);
        ButtonShow();
    }

    public void RUSure() {
        four = false;
        four_rusure = true;
        Next(fourth, fourth_rusure);
        ButtonOff(buttonsInteract, 1);
        ButtonShow();
    }

    public void OnlyOne() {
        four = false;
        four_onlyone = true;
        Next(fourth, fourth_onlyone);
        ButtonOff(buttonsInteract, 2);
        ButtonShow();
    }

    public void How() {
        shopScript.secretScroll = true;
        four = false;
        four_how = true;
        Next(fourth, fourth_how);
        ButtonOff(buttonsInteract, 3);
        ButtonShow();
    }

    public void NoQ() {
        four = false;
        four_noq = true;
        Next(fourth, fourth_noq);
    }

    public void Bye() {
        Next(first, null);
        Next(fourth, null);
        bye.SetActive(true);
        end = true;
    }
}
