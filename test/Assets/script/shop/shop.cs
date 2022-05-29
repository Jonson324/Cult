using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour {
    private DataPlayer dataPlayer = new DataPlayer();
    public inDialog inDialog;
    public task taskScript;
    [HideInInspector] public string nameItem; //имя товара
    [HideInInspector] public int priceItem; //цена товара
    public GameObject Shop; //магазин
    public Text monk; //отображение денег
    public GameObject[] allItem;  //массив товаров

    public List<Button> pageButtons = new List<Button>();
    public List<GameObject> pageList = new List<GameObject>();
    public int current_page;
    public int next_page;
    public GameObject about_message;
    public bool about;
    public AudioSource buy;

    public class DataPlayer {
        public int money;
        public List<string> buyItem = new List<string>();
    }

    public void Start() {
        if (PlayerPrefs.HasKey("saveGame")) {
            loadGame();
        } else {
            saveGame();
            loadGame();
        }
        pageButtons[current_page].interactable = false;
    }

    private void Update() {
        monk.text = "Деньги: " + dataPlayer.money;
        if ((about) && (Input.GetKeyDown(KeyCode.Mouse0))) {
            about_message.SetActive(false);
            about = false;
        }
    }

    private void saveGame() {
        PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(dataPlayer));
    }

    private void loadGame() {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("saveGame"));

        for (int i = 0; i < dataPlayer.buyItem.Count; i++) {
            for (int j = 0; j < allItem.Length; j++) {
                if (allItem[j].GetComponent<item>().nameItem.text.ToString() == dataPlayer.buyItem[i]) {
                    allItem[j].GetComponent<item>().priceItem.text = "Куплено";
                    allItem[j].GetComponent<item>().priceObj[0].SetActive(false);
                    allItem[j].GetComponent<item>().priceObj[1].SetActive(false);
                    allItem[j].GetComponent<item>().buyed.SetActive(true);
                    allItem[j].GetComponent<item>().isBuy = true;
                }
            }
        }
    }

    public void buyItem() {
        if (dataPlayer.money >= priceItem) {
            dataPlayer.buyItem.Add(nameItem);
            dataPlayer.money -= priceItem;
            buy.Play();
            saveGame();
            loadGame();
        }
    }

    public void closeShop() {
        Shop.SetActive(false);
        taskScript.bye = true;
        pageList[current_page].SetActive(false);
        pageList[0].SetActive(true);
        pageButtons[current_page].interactable = true;
        pageButtons[0].interactable = false;
        current_page = 0;
    }

    public void Robe() {
        next_page = 0;
        nextPage();
    }

    public void Arm() {
        next_page = 1;
        nextPage();
    }

    public void Ring() {
        next_page = 2;
        nextPage();
    }

    public void Crystall() {
        next_page = 3;
        nextPage();
    }

    private void nextPage() {
        pageList[current_page].SetActive(false);
        pageList[next_page].SetActive(true);
        pageButtons[current_page].interactable = true;
        pageButtons[next_page].interactable = false;
        current_page = next_page;
    }

    public void aboutShow() {
        about_message.SetActive(true);
        about = true;
    }
}
