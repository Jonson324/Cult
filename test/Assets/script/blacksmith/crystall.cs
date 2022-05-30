using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystall : MonoBehaviour {
    public forge forgeScript;
    public Text crystall_name;
    public Text crystall_status;
    public bool current;

    public void CrystallChange() {
        if (current == false) {
            forgeScript.crystall_name = crystall_name.text;
            forgeScript.crystall_status = crystall_status.text;
            forgeScript.CrystallChange();
        }
    }
}
