using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScena : MonoBehaviour
{
    public int sceneIndex;
    public roomsch roomsch;

    private void Update()
    {
        if (roomsch.chk == true)
        {
            sceneIndex =  11;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

}
