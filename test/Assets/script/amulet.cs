using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amulet : MonoBehaviour {
    public static int damage = 10;
    public static float dmg_multiplier;
    public static int free_points;

    public static string currentCrystall = "Флейм кристалл";
    public static string previousCrystall;
    public static float cooldown;
    public static int k;

    public static bool boss_weakened;
    public static bool hammer_found = true;

    private void Update() {
        if (currentCrystall == "Флейм кристалл") {
            dmg_multiplier = 1f;
            cooldown = 0.4f;
            k = 0;
        }
        if (currentCrystall == "Аква кристалл") {
            dmg_multiplier = 0.25f;
            cooldown = 0.05f;
            k = 1;
        }
        if (currentCrystall == "Терра кристалл") {
            dmg_multiplier = 2f;
            cooldown = 1.2f;
            k = 2;
        }
        if (currentCrystall == "Аеро кристалл") {
            dmg_multiplier = 0.5f;
            cooldown = 0.1f;
            k = 3;
        }
    }

    public void Clean() {
        damage = 10;
        LevelHealth.maxhealth = 100;
        free_points = 0;
        currentCrystall = "Флейм кристалл";
        previousCrystall = "";
        boss_weakened = false;
        hammer_found = true;

        task.quest_started = false;
        task.quest_completed = false;
        dialog.scrolled = false;

        interact.start = true;
        interact.first = false;
        interact.quest_completed = false;
        talk.good = false;
        talk.jade_only = false;

        enemy_hp.bossDefeated = false;

        PlayerPrefs.DeleteKey("saveGame");
        PlayerPrefs.DeleteKey("jade");
    }
}
