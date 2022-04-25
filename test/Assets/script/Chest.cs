using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<Items> items;

    public GameObject hint;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hint.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            hint.SetActive(false);

            Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся рандомный предмет через рандомное взятое число от 0 до количества предметов


        }
    }

    void OnTriggerExit(Collider other)
    {
        hint.SetActive(false);
    }




}