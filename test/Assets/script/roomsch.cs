using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomsch : MonoBehaviour
{

    public enamyCount enamyCount;
    public static bool chk;
    private void Update()
    {
        if (enamyCount.count == 19)
        {
            chk = true;
        }
        else chk = false;
        
    
    }
    
}
