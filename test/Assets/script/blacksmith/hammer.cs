using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour {
    public interact interactScript;

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            interactScript.first = false;
            interactScript.quest_completed = true;
            interactScript.quest_task.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
