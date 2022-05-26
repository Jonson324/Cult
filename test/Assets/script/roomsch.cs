using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomsch : MonoBehaviour
{

    public enamyCount enamyCount;
    public bool chk;
    private void Update()
    {
        if (enamyCount.count == 20)
        {
            chk = true;
        }
        else chk = false;
        
    
    }
    
}
