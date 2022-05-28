using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] public List<Items> items;
    public static bool opened;
    //public GameObject lighth;

    public void Update()
    {
        
    }

    public void OnTriggerStay(Collider other) {
        Vector3 a = transform.position;
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && (opened == false))
            {
                Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся предмет через рандомное взятое число от 0 до количества предметов
                gameObject.GetComponent<Animator>().Play("Opening");
                opened = true;
                //lighth.SetActive(true);
            }
        }
        
    }
}