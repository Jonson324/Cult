using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_object : MonoBehaviour {
    public task taskScript; //ссылка на скрипт взаимодействия с npc
    
    void OnTriggerEnter (Collider col) {
        if (col.tag == "Player") {
            taskScript.quest_started = false;
            taskScript.quest_completed = true;
            taskScript.thx1 = true;
            gameObject.SetActive(false);
        }
    }
}
