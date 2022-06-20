using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;

    public static float SPEED;
    public static float start_speed = 8f;
    public float gravity = -9.8f;// сила гравитации

    Vector3 velocity;// переменная для расчета

    public Transform grountCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHieght = 6f;
    public bool isGrounded;



    private void Start()
    {
        SPEED = start_speed;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "speedup")
        {
            SPEED *= 1.8f;
            StartCoroutine(ResetSpeed(7));
            Destroy(GameObject.FindGameObjectWithTag("speedup"));
        }
    }

    private IEnumerator ResetSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        SPEED = start_speed;
    }

}
