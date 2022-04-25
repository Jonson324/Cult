using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{

    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireboll")
        {
            Health -= 50;
            Debug.Log(Health);
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
            
        }
        
    }

}
