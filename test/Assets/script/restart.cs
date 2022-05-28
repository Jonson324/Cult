using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public LevelHealth health;
    public void restartlevel()
    {
        health.start = true;
        SceneManager.LoadScene(1);
    }
}
