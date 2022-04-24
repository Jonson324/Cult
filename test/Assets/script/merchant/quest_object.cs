using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_object : MonoBehaviour
{
    public quest_event quest_event; //ссылка на скрипт с заданием
    public task taskScript; //ссылка на скрипт взаимодействия с npc
    
    void OnTriggerEnter (Collider col) {
        if (col.tag == "Player") {
            quest_event.quest_ring_end = true;
            Destroy(gameObject);
            taskScript.ring_obtained = true;
            taskScript.EndDialog1 = false;
        }
    }
}
