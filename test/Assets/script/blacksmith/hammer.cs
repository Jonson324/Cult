using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour {
    public interact interactScript;

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            interactScript.endQuest();
            interactScript.quest_task.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
