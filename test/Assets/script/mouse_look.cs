using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouseSens = 1000f;//скорость мыши
    public Transform playerBody;//для персонажа
    float xRotation = 0f;//по оси х

    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;//обновелние позиции мыши каждый тик по оси х
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;//обновелние позиции мыши каждый тик по оси у

        xRotation -= mouseY;//предел камеры по оси y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//ограничение на предел

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);//движение персонажа за мышью
    }
}
