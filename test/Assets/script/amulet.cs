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

    public static bool boss_weakened;

    private void Update() {
        if (currentCrystall == "Флейм кристалл") {
            dmg_multiplier = 1f;
            cooldown = 0.4f;
        }
        if (currentCrystall == "Аква кристалл") {
            dmg_multiplier = 0.25f;
            cooldown = 0.05f;
        }
        if (currentCrystall == "Терра кристалл") {
            dmg_multiplier = 2.5f;
            cooldown = 1f;
        }
        if (currentCrystall == "Аеро кристалл") {
            dmg_multiplier = 0.5f;
            cooldown = 0.1f;
        }
    }

    public void Clean() {
        damage = 10;
        free_points = 0;
        currentCrystall = "Флейм кристалл";
        previousCrystall = "";
        boss_weakened = false;
    }
}
