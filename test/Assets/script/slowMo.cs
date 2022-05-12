using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMo : MonoBehaviour
{

    public float slowMovalue = 0.09f;
    public float slowMoDuration = 5f;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0.0f, 1.0f);
        Time.timeScale += (1f/ slowMoDuration) * Time.unscaledDeltaTime;
        Time.fixedDeltaTime += (0.02f / slowMoDuration) * Time.unscaledDeltaTime;
    }

    public void SlowMotion()
    {
        Time.timeScale = slowMovalue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
