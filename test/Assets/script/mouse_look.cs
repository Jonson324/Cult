using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse_look : MonoBehaviour
{
    public float mouseSens;//�������� ����
    public Transform playerBody;//��� ���������
    float xRotation = 0f;//�� ��� �
    public float maxSens = 10f;

    sensetivity sensetivity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;//���������� ������� ���� ������ ��� �� ��� �
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;//���������� ������� ���� ������ ��� �� ��� �

        xRotation -= mouseY;//������ ������ �� ��� y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//����������� �� ������

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);//�������� ��������� �� �����
        mouseSens = sensetivity.slValue;

    }

    public void Sensetivity()
    {
        mouseSens = sensetivity.SliderSens.value * maxSens * Time.deltaTime;
    }
}
