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

            Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //������ ��������� ������� ����� ��������� ������ ����� �� 0 �� ���������� ���������


        }
    }

    void OnTriggerExit(Collider other)
    {
        hint.SetActive(false);
    }




}