using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enamyCount : MonoBehaviour
{
    Text text;
    public static int count;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = count.ToString();
    }
}
