using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<Items> items;


    public void Useble()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся рандомный предмет через рандомное взятое число от 0 до количества предметов
        }
    }

    




}