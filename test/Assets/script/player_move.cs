using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;

    public static float SPEED;
    public static float start_speed = 15.0f;
    public float gravity = -9.8f;// ���� ����������

    Vector3 velocity;// ���������� ��� �������

    public Transform grountCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHieght = 6f;


    private void Start()
    {
        SPEED = start_speed;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");// ���������� ��� ������������ �� ��� �
        float z = Input.GetAxis("Vertical");// ���������� ��� ������������ �� ��� z

        Vector3 move = transform.right * x + transform.forward * z; // ������ ����������� ���������


        controller.Move(move * SPEED * Time.deltaTime);// ������ �������� ���������

        velocity.y += gravity * Time.deltaTime;// ������ ����������
        controller.Move(velocity * Time.deltaTime);// ���������� ���������� � ���������

        isGrounded = Physics.CheckSphere(grountCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "speedup")
        {
            SPEED *= 1.2f;
            StartCoroutine(ResetSpeed(30));
        }
    }

    private IEnumerator ResetSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        SPEED = start_speed;
    }
}
