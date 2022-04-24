using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task : MonoBehaviour
{
    public bool EndDialog1; //окончание первого монолога
    public bool EndDialog2; //окончание второго монолога
    public GameObject dialog1; //первый монолог
    public GameObject dialog1_end; //второй монолог
    public GameObject LevelHealth; //шкала здоровья
    public quest_event quest_event; //ссылка на скрипт с заданием
    public GameObject Hint; //подсказка вверху экрана
    public GameObject shop; //магазин
    public bool dialog1_end_disable; //отключение диалогов
    public bool ring_obtained; //флаг выполнения задания

    // Update is called once per frame
    void Update()
    {
        if (EndDialog1 == true) {
            Time.timeScale = 1;
            dialog1.SetActive(false);
            LevelHealth.SetActive(true);
            quest_event.quest_ring = true;
        }
        if (EndDialog2 == true) {
            Time.timeScale = 1;
            quest_event.quest_ring = false;
            dialog1_end.SetActive(false);
            LevelHealth.SetActive(true);
            dialog1_end_disable = true;
            EndDialog2 = false;
        }
    }

    void OnTriggerEnter (Collider col) {
        if (col.tag == "Player") {
            Hint.SetActive(true);
        }
    }

    void OnTriggerStay (Collider col) {
        if (Input.GetKey(KeyCode.E)) {
            Time.timeScale = 0; //pause
            Hint.SetActive(false);
            LevelHealth.SetActive(false);
            if (ring_obtained == false) {
                dialog1.SetActive(true);
            } else {
                if (dialog1_end_disable == false) {
                    Time.timeScale = 0; //pause 
                    dialog1_end.SetActive(true);
                } else {
                    Time.timeScale = 0; //pause 
                    shop.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

    void OnTriggerExit (Collider col) {
        Hint.SetActive(false);
    }
}
