using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;

    public float SPEED = 15f;// скорость перемещения

    public float gravity = -9.8f;// сила гравитации

    Vector3 velocity;// переменная для расчета

    public Transform grountCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHieght = 6f;

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");// переменная для передвижения по оси х
        float z = Input.GetAxis("Vertical");// переменная для передвижения по оси z

        Vector3 move = transform.right * x + transform.forward * z; // расчет направления персонажа


        controller.Move(move * SPEED * Time.deltaTime);// расчет скорости персонажа

        velocity.y += gravity * Time.deltaTime;// расчет гравитации
        controller.Move(velocity * Time.deltaTime);// применение гравитации к персонажу

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
}
