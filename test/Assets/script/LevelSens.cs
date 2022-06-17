using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSens : MonoBehaviour
{
    private static readonly string Sensetivity = "sensetivity";

    [SerializeField] public Slider SliderSens;
    [SerializeField] public Text synstxt;
    public float slValue;

    private void Awake()
    {
        LevelSensetivity();
    }

    private void LevelSensetivity()
    {
        slValue = PlayerPrefs.GetFloat(Sensetivity);

        SliderSens.value = slValue;
    }
}
