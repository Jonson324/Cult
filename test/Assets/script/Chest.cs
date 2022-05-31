using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] public List<Items> items;
    public bool opened;
    public GameObject hint;
    public static bool chest;
    //public GameObject lighth;

    public void OnTriggerStay(Collider other) {
        Vector3 a = transform.position;
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && (opened == false))
            {
                Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся предмет через рандомное взятое число от 0 до количества предметов
                gameObject.GetComponent<Animator>().Play("Opening");
                amulet.free_points += 2;
                hint.SetActive(false);
                //lighth.SetActive(true);
                opened = true;
                chest = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        if ((other.tag == "Player") && (opened == false)) {
            hint.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            hint.SetActive(false);
        }
    }
}