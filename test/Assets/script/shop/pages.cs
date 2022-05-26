using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pages : MonoBehaviour {
    public shop shopScript;
    public GameObject[] allItem;//массив товаров

    public void Update() {
        if (gameObject.activeInHierarchy == true) { 
            shopScript.allItem = allItem;
        } else {
            shopScript.allItem = null;
        }
    }
}