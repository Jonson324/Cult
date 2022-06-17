using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScena : MonoBehaviour
{
    public int sceneIndex;
    public GameObject hint;
    private bool a;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((Input.GetKey(KeyCode.E) && (task.quest_started == false) && (interact.first == false))) 
            {
                hint.SetActive(false);
                SceneManager.LoadScene(sceneIndex);
               
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (task.quest_started == false) && (interact.first == false))
        {
            hint.SetActive(true);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hint.SetActive(false);
        }
    }
}
