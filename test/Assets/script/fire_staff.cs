using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_staff : MonoBehaviour
{
    public GameObject fireboll;
    public float fbspeed = 200f;
    public float fbdist = 100f;
    public bool fire;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<fire_staff>().fire = fire;
        }

        if (this.GetComponent<fire_staff>().fire == true)
        {
            fireboll.transform.position += transform.TransformDirection(Vector3.forward) * (fbspeed * Time.deltaTime);
            
            if ((this.transform.position - fireboll.transform.position).sqrMagnitude > fbdist)
            {
                this.GetComponent <fire_staff>().fire = false;
            }
        } else
        {
            fireboll.transform.localPosition = new Vector3(9.52f, 3.505f, 10.42f);
        }
    }
}
