using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opench : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("Opening");
    }
}
