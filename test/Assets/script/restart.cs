using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public amulet amuletScript;
    public inDialog inDialogScript;

    public void restartlevel()
    {
        amuletScript.Clean();
        inDialogScript.in_dialog = false;
        LevelHealth.levelHealth = 100;
        SceneManager.LoadScene(1);
    }
}
