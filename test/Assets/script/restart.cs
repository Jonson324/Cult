using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public amulet amuletScript;

    public void restartlevel()
    {
        amuletScript.Clean();
        LevelHealth.levelHealth = 100;
        SceneManager.LoadScene(1);
    }
}
