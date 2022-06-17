using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour {
    public interact interactScript;
    // ÏÓÑÒÜ ÏÎßÂËßÅÒÑß ÍÀ ÍÀÊÀÂÀËÜÍÅ Â ÌÀÃÀÇÈÍÅ, ÅÑËÈ ÊÂÅÑÒ ÂÛÏÎËÍÅÍ

    void Start() {
        if (interact.start == true) {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col) {
        if ((col.tag == "Player") && (interact.first == true)) {
            interact.first = false;
            interact.quest_completed = true;
            interactScript.quest_task.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
