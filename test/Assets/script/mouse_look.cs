using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse_look : MonoBehaviour
{
    public float mouseSens;//скорость мыши
    public Transform playerBody;//для персонажа
    float xRotation = 0f;//по оси х
    public float maxSens = 10f;

    sensetivity sensetivity;


    void Start()
    {
        mouseSens = sensetivity.slValue;
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;//обновелние позиции мыши каждый тик по оси х
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;//обновелние позиции мыши каждый тик по оси у

        xRotation -= mouseY;//предел камеры по оси y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//ограничение на предел

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);//движение персонажа за мышью

        
    }

    public void Sensetivity()
    {
        mouseSens = sensetivity.SliderSens.value * maxSens;
    }
}
