using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private DataPlayer dataPlayer = new DataPlayer();
    public int value;

    public class DataPlayer {
        public int money = 0;
        public List<string> buyItem = new List<string>();
    }

    float speed = 2;
    private void Start()
    {
        if (Chest.chest == true) {
            value = Random.Range(750, 1500);
            Chest.chest = false;
        } else { value = Random.Range(75, 150); }
    }
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y > 63.501)
        {
            speed = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.HasKey("saveGame"))
            {
                dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("saveGame"));
            }
            dataPlayer.money += value;
            PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(dataPlayer));
            Destroy(gameObject);
        }
    }
}
