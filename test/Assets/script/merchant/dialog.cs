using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour {
    public task taskScript;
    [HideInInspector] public bool one;
    public List<GameObject> first = new List<GameObject>();
    [HideInInspector] public bool two;
    public List<GameObject> second = new List<GameObject>();
    [HideInInspector] public bool three;
    public List<GameObject> third = new List<GameObject>();
    [HideInInspector] public bool four;
    public List<GameObject> fourth = new List<GameObject>();
    public GameObject bye;
    [HideInInspector] public bool end;
    int i = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (taskScript.talkin == true)) {
            if (one == true) { 
                Continue(first, out one);
            }

            if (two == true) {
                Continue(second, out two);
            }

            if (three == true) {
                Continue(third, out three);
            }

            if (four == true) {
                Continue(fourth, out four);
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
    }

    public void Yes() {
        two = true;
        Next(first, second);
    }

    public void Unbelivable() {
        three = true;
        Next(second, third);
    }

    public void Questions() {
        four = true;
        Next(second, fourth);
    }

    public void Bye() {
        Next(first, null);
        Next(second, null);
        bye.SetActive(true);
        end = true;
    }
}
