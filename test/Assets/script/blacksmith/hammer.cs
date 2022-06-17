using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour {
    public interact interactScript;
    // ����� ���������� �� ���������� � ��������, ���� ����� ��������

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
