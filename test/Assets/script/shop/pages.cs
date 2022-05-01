using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pages : MonoBehaviour {
    public GameObject prevPage;
    public GameObject currentPage;
    public GameObject nextPage;

    public void previous() {
        currentPage.SetActive(false);
        prevPage.SetActive(true);
    }

    public void next() {
        currentPage.SetActive(false);
        nextPage.SetActive(true);
    }
}