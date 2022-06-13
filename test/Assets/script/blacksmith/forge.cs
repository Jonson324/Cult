using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forge : MonoBehaviour {
    private DataPlayer dataPlayer = new DataPlayer();
    public interact interactScript;

    public GameObject buttons;
    public GameObject amulet_menu;
    public GameObject crystall_menu;
    public GameObject back_button;
    public Text topic;
    public List<Text> level = new List<Text>();
    public static int hp_level;
    public static int dmg_level;
    public Text skill_points;

    public GameObject price_obj;
    public Text money;
    public Text price_tag;
    public static int price = 500;

    public GameObject[] allCrystalls;
    [HideInInspector] public string crystall_name; //имя товара
    [HideInInspector] public string crystall_status; //цена товара
    public AudioSource crystallSound;
    public AudioSource amuletSound;

    public class DataPlayer {
        public int money = 0;
        public List<string> buyItem = new List<string>();
    }

    private void Start() {
        skill_points.text = "Кол-во очков: " + amulet.free_points;
        if (PlayerPrefs.HasKey("saveGame")) {
            loadGame();
        } else {
            saveGame();
            loadGame();
        }
    }

    private void Update() {
        skill_points.text = "Кол-во очков: " + amulet.free_points;
        money.text = "Деньги: " + dataPlayer.money.ToString();
        price_tag.text = "Цена услуги: " + price.ToString();
    }

    private void saveGame() {
        PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(dataPlayer));
    }

    private void loadGame() {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("saveGame"));

        for (int i = 0; i < dataPlayer.buyItem.Count; i++) {
            for (int j = 0; j < allCrystalls.Length; j++) {
                if (allCrystalls[j].GetComponent<crystall>().crystall_name.text.ToString() == dataPlayer.buyItem[i] &&
                (allCrystalls[j].GetComponent<crystall>().crystall_status.text == "Отсутствует")) {
                    allCrystalls[j].GetComponent<crystall>().crystall_status.text = "В наличии";
                }
                if (allCrystalls[j].GetComponent<crystall>().crystall_name.text.ToString() == amulet.currentCrystall) {
                    allCrystalls[j].GetComponent<crystall>().crystall_status.text = "Установлено";
                    allCrystalls[j].GetComponent<crystall>().current = true;
                }
                if (allCrystalls[j].GetComponent<crystall>().crystall_name.text.ToString() == amulet.previousCrystall) {
                    allCrystalls[j].GetComponent<crystall>().crystall_status.text = "В наличии";
                    allCrystalls[j].GetComponent<crystall>().current = false;
                }
            }
        }
    }

    public void Amulet() {
        buttons.SetActive(false);
        amulet_menu.SetActive(true);
        back_button.SetActive(true);
        topic.text = "Амулет";
        price_obj.SetActive(true);
    }

    public void Crystall() {
        buttons.SetActive(false);
        crystall_menu.SetActive(true);
        back_button.SetActive(true);
        topic.text = "Кристалл";
        price_obj.SetActive(true);
        if (PlayerPrefs.HasKey("saveGame")) {
            loadGame();
        } else {
            saveGame();
            loadGame();
        }
    }

    public void Back() {
        price_obj.SetActive(false);
        back_button.SetActive(false);
        amulet_menu.SetActive(false);
        crystall_menu.SetActive(false);
        buttons.SetActive(true);
        topic.text = "Кузница";
    }

    public void HealthUp() {
        if ((hp_level < 3) && (amulet.free_points > 0)) {
            LevelHealth.maxhealth += 5;
            hp_level += 1;
            Upgrade(0, hp_level);
        }
        
    }

    public void DamageUp() {
        if ((dmg_level < 3) && (amulet.free_points > 0)) {
            amulet.damage += 1;
            dmg_level += 1;
            Upgrade(1, dmg_level);
        }
    }

    void Upgrade(int count, int stat) {
        level[count].text = stat + "/3";
        amulet.free_points -= 1;
        amuletSound.Play();
    }

    public void CloseForge() {
        interactScript.CloseForge();
        Back();
    }

    public void CrystallChange() {
        if ((dataPlayer.money >= price) && (crystall_status == "В наличии")) {
            crystallSound.Play();
            amulet.previousCrystall = amulet.currentCrystall;
            amulet.currentCrystall = crystall_name;
            dataPlayer.money -= price;
            saveGame();
            loadGame();
        }
    }
}
