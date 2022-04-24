using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    private shop.DataPlayer dataPlayer = new shop.DataPlayer();

    [HideInInspector]
    public string nameItem; //имя товара
    [HideInInspector]
    public int priceItem; //цена товара
    public GameObject Shop; //магазин
    public Text monk; //отображение денег
    public GameObject[] allItem;  //массив товаров

    public class DataPlayer {
        public int money;

        public List<string> buyItem = new List<string>();
    }

    private void Start() {
        if (PlayerPrefs.HasKey("saveGame")) {
            loadGame();
        } else {
            dataPlayer.money = 2000;
            saveGame();
            loadGame();
        }
    }

    private void Update() {
        monk.text = "Деньги: " + dataPlayer.money;
    }

    private void saveGame() {
        PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(dataPlayer));
    }

    private void loadGame() {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("saveGame"));

        for (int i = 0; i < dataPlayer.buyItem.Count; i++) {
            for (int j = 0; j < allItem.Length; j++) {
                if (allItem[j].GetComponent<item>().nameItem == dataPlayer.buyItem[i]) {
                    allItem[j].GetComponent<item>().textItem.text = "Куплено";
                }
            }
        }
    }

    public void buyItem() {
        if (dataPlayer.money >= priceItem) {
            dataPlayer.buyItem.Add(nameItem);
            dataPlayer.money -= priceItem;

            saveGame();
            loadGame();
        }
    }

    public void closeShop() {
        Shop.SetActive(false);
        Time.timeScale = 1; //pause 
        Cursor.lockState = CursorLockMode.Locked;
    }
}
