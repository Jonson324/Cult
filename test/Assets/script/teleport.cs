using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject teleportPoint;
    
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("go");
            other.gameObject.transform.position = teleportPoint.gameObject.transform.position;
        }
    }
}
