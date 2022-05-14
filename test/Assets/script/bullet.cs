using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    private void OnCollisionStay(Collision collision)
    {

        Destroy(GameObject.FindGameObjectWithTag("fireboll"));

    }


}
