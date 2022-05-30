using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jade : MonoBehaviour {
    public GameObject hint;
    private DataPlayer dataPlayer = new DataPlayer();

    public class DataPlayer {
        public int jade_active = 0;
        public int jade_earned = 0;
    }

    private void OnTriggerEnter(Collider other) {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("jade"));
        if ((other.tag == "Player") && (dataPlayer.jade_active == 1)) {
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            hint.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) {
        if ((other.tag == "Player") && (dataPlayer.jade_active == 1)) {
            if (Input.GetKey(KeyCode.E)) {
                dataPlayer.jade_active = 0;
                dataPlayer.jade_earned = 1;
                PlayerPrefs.SetString("jade", JsonUtility.ToJson(dataPlayer));
                gameObject.SetActive(false);
                hint.SetActive(false);
            }
        }
    }
}
