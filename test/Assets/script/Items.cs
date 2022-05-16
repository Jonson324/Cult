using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    float speed = 2;
    private void Start()
    {
        
    }
    private void Update()
    {
        
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y > 63.501)
        {
            speed = 0;
        } 
    }
}
