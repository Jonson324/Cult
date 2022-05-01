using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pages : MonoBehaviour {
    public shop shopScript;
    public GameObject prevPage;
    public GameObject currentPage;
    public GameObject nextPage;
    public GameObject[] allItem;//массив товаров

    public void Update() {
        if (gameObject.activeInHierarchy == true) { 
            shopScript.allItem = allItem;
        } else {
            shopScript.allItem = null;
        }
    }

    public void previous() {
        currentPage.SetActive(false);
        prevPage.SetActive(true);
    }

    public void next() {
        currentPage.SetActive(false);
        nextPage.SetActive(true);
    }
}