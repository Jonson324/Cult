using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeadCamera;
    public GameObject Parent;
    public GameObject PanelDead;
    public static float levelHealth;
    
    public Text txt;
    public float maxhealth = 100;
    public bool start;
    
    private bool isOnDeadZone = false;

   
    void Start()
    {
        levelHealth = 100; //Комментируй строку, если тестишь с главного меню
        Player = gameObject;
    }


    void Update()
    {
        if ((levelHealth > maxhealth) || (start == true))
        {
            start = false;
            levelHealth = maxhealth;
        }

        txt.text = "HP " + Mathf.Floor(levelHealth);

        if (levelHealth <= 0)
        {
            PanelDead.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeadCamera.SetActive(true);
            DeadCamera.transform.parent = Parent.transform;
            Destroy(gameObject);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "deadzone")
        {
            isOnDeadZone = true;
            levelHealth = levelHealth - 5 * Time.deltaTime;
        }

        if (other.tag == "Health")
        {
            levelHealth += 20;
            Destroy(GameObject.FindGameObjectWithTag("Health"));
        }
        if (other.tag == "sword")
        {
            levelHealth -= 25;
        }
        if(other.tag == "CultistAttack")
        {
            levelHealth -= 15;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "deadzone")
        {
            levelHealth = levelHealth - 5 * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "deadzone")
        {
            isOnDeadZone = false;
        }
    }
}
