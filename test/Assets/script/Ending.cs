using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {
    public GameObject hint;
    public GameObject task;
    public GameObject ending;
    static float time_left;
    static float read_time = 17f;
    public static bool end;
    static bool true_end;
    int i;
    public List<GameObject> text = new List<GameObject>();

    void Update() {
        if (time_left > 0) {
            time_left -= Time.deltaTime;
        }

        if ((end == true) && (time_left <= 0)) {
            if (i != text.Count - 1) {
                text[i].SetActive(false);
                text[i + 1].SetActive(true);
                i++; time_left = read_time;
            }
            else {
                end = false;
                SceneManager.LoadScene(0);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (true_end == true) {
            text[i].SetActive(false);
            ending.SetActive(false);
            true_end = false;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if ((collider.tag == "Player") && (enemy_hp.bossDefeated == true)) {
            hint.SetActive(true);
            task.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collider) {
        if ((collider.tag == "Player") && (enemy_hp.bossDefeated == true)) {
            hint.SetActive(false);
            task.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collider) {
        if ((collider.tag == "Player") && (enemy_hp.bossDefeated == true)) {
            if (Input.GetKey(KeyCode.E)) {
                hint.SetActive(false);
                ending.SetActive(true);
                text[0].SetActive(true);
                time_left = read_time;
                end = true;
            }
        }
    }

    public static void End() {
        true_end = true;
    }
}