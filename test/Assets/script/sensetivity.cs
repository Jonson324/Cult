using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensetivity : MonoBehaviour
{
    private static readonly string Sensetivity = "sensetivity";
    [SerializeField] public Slider SliderSens;
    [SerializeField] public Text synstxt;
    public static float slValue;

    
    void Start()
    {

        slValue = PlayerPrefs.GetFloat(Sensetivity);

        if (slValue == 0)
        {
            slValue = 2f;
            PlayerPrefs.SetFloat(Sensetivity, slValue);
        }
        else
        {
            slValue = PlayerPrefs.GetFloat(Sensetivity);
            SliderSens.value = slValue;
        }

        SliderSens.onValueChanged.AddListener((v) =>
        {
            synstxt.text = v.ToString("0");
        });
    }

    public void ChangeSlider(float value)
    {
        slValue = value;  
    }

    public void SaveSens()
    {
        PlayerPrefs.SetFloat(Sensetivity, slValue);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if (infocus)
        {
            SaveSens();
        }
    }

}
