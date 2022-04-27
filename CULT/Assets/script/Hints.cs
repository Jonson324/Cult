using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject hint;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        hint.SetActive(false);
    }
}
