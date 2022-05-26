using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
   [SerializeField] public int money ;

    float speed = 2;
    private void Start()
    {
        money = Random.Range(0, 1000);
    }
    private void Update()
    {
        
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y > 63.501)
        {
            speed = 0;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
