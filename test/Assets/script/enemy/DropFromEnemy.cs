using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromEnemy : MonoBehaviour
{
    public GameObject enem;
    public int hl = 20;
    public GameObject prefab;
    
    [SerializeField] public List<Items> items;

    [SerializeField] public List<Items> Rareitems;


    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся рандомный предмет через рандомное взятое число от 0 до количества предметов
            Destroy(prefab);

        }
    }
}
