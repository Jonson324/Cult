using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forge : MonoBehaviour {
    public interact interactScript;
    public amulet amuletScript;
    public LevelHealth levelHealtScript;
    public GameObject buttons;
    public GameObject amulet_menu;
    public GameObject crystall_menu;
    public GameObject back_button;
    public Text topic;
    public List<Text> level = new List<Text>();
    [HideInInspector] public int hp_level;
    [HideInInspector] public int dmg_level;
    [HideInInspector] public int mp_level;
    public Text skill_points;

    private void Start() {
        skill_points.text = "Кол-во очков: " + amuletScript.nonstatic_pts;
    }

    private void Update() {
        skill_points.text = "Кол-во очков: " + amuletScript.nonstatic_pts;
    }

    public void Amulet() {
        buttons.SetActive(false);
        amulet_menu.SetActive(true);
        back_button.SetActive(true);
        topic.text = "Амулет";
    }

    public void Crystall() {
        buttons.SetActive(false);
        crystall_menu.SetActive(true);
        back_button.SetActive(true);
        topic.text = "Кристалл";
    }

    public void Back() {
        back_button.SetActive(false);
        amulet_menu.SetActive(false);
        crystall_menu.SetActive(false);
        buttons.SetActive(true);
        topic.text = "Кузница";
    }

    public void HealthUp() {
        if ((hp_level < 3) && (amuletScript.nonstatic_pts > 0)) {
            levelHealtScript.HealthUpgrade(5);
            hp_level += 1;
            Upgrade(0, hp_level);
        }
        
    }

    public void DamageUp() {
        if ((dmg_level < 3) && (amuletScript.nonstatic_pts > 0)) {
            amuletScript.DamageUpgrade(1);
            dmg_level += 1;
            Upgrade(1, dmg_level);
        }
    }

    void Upgrade(int count, int stat) {
        level[count].text = stat + "/3";
        amuletScript.PointsUpgrade(-1);
    }

    public void CloseForge() {
        interactScript.CloseForge();
        Back();
    }
}
