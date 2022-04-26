using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NewScene : MonoBehaviour
{
    public int sceneId;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            EditorSceneManager.LoadScene(sceneId);
        }
    }
}
