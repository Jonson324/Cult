using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObject : MonoBehaviour
{
    public int HealthObj = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireboll")
        {
            HealthObj -= 100;
            Debug.Log(HealthObj);
            if (HealthObj <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
