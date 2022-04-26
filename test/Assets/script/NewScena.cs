using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NewScena : MonoBehaviour
{
    public int sceneIndex;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EditorSceneManager.LoadScene(sceneIndex);
        }
    }
}
