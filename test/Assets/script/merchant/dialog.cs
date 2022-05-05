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

    void Start() { first[0].SetActive(true); one = true; }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (taskScript.talkin == true)) {
            if (one == true) { 
                Continue(first);
            }

            if (two == true) {
                Continue(second);
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
        Next(first, second);
        one = false;
        two = true;
    }

    public void Bye() {
        i = 0;
        taskScript.talkin = false;
        taskScript.talk.SetActive(false);
        second[second.Count - 2].SetActive(false);
        second[second.Count - 1].SetActive(false);
        first[0].SetActive(true);
        one = true;
        two = false;
        taskScript.shop_doalog.SetActive(true);
    }
}
