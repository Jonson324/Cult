using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour {
    public task taskScript;
    int i = 0;
    [HideInInspector] public bool one;
    public List<GameObject> first = new List<GameObject>();
    [HideInInspector] public bool two;
    public List<GameObject> second = new List<GameObject>();
    public GameObject bye;
    [HideInInspector] public bool end;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (taskScript.talkin == true)) {
            if (one == true) { 
                Continue(first);
            }

            if (two == true) {
                Continue(second);
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

    void Continue(List<GameObject> name) {
        if (i != name.Count - 2) {
            name[i].SetActive(false);
            name[i + 1].SetActive(true);
            i++;
        } else { name[i + 1].SetActive(true); }
    }

    void Next(List<GameObject> prev, List<GameObject> next) {
        prev[prev.Count - 2].SetActive(false);
        prev[prev.Count - 1].SetActive(false);
        next[0].SetActive(true);
    }

    public void YesNo() {
        i = 0;
        one = false; two = true;
        Next(first, second);
    }

    public void Bye() {
        i = 0;
        two = false;
        second[second.Count - 2].SetActive(false);
        second[second.Count - 1].SetActive(false);
        bye.SetActive(true);
        end = true;
    }
}
