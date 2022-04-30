using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{
    [SerializeField] public List<Items> Rareitems;
    [SerializeField] public List<Items> items;
    public double Health = 100;
   
    void Start()
    {

    }


    void Update()
    {
        
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireboll")
        {
            Health -= 20.5;
            Debug.Log(Health);
            if (Health <= 0)
            {
                Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity); //Берётся рандомный предмет через рандомное взятое число от 0 до количества предметов
                Destroy(gameObject);
            }
            
        }
        
    }

}
