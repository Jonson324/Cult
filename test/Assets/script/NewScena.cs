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
        if ((other.tag == "Player") && (interact.quest_completed == false) && (interact.first == false))
        {
            if (Input.GetKey(KeyCode.E))
            {
                hint.SetActive(false);
                if ((SceneManager.GetActiveScene().buildIndex == 1) && (interact.start == true)) {
                    amulet.hammer_found = false;
                }
                SceneManager.LoadScene(sceneIndex);
               
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (interact.quest_completed == false) && (interact.first == false))
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
