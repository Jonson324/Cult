using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amulet : MonoBehaviour {
    public static int damage = 10;
    public static int free_points = 2;
    public int nonstatic_pts;
    public int nonstatic_dmg;
    public static bool boss_weakened;

    void Update() {
        nonstatic_pts = free_points;
        nonstatic_dmg = damage;
    }

    public void ScrollActivate() {
        boss_weakened = true;
    }

    public void DamageUpgrade(int x) {
        damage += x;
    }

    public void PointsUpgrade(int x) {
        free_points += x;
    }
}
