using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] public List<Items> items;
    public GameObject lighth;

    public void Update()
    {
        Vector3 a = transform.position;
         if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся предмет через рандомное взятое число от 0 до количества предметов
            gameObject.GetComponent<Animator>().Play("Opening");
            lighth.SetActive(true);
        }
    }
   




}