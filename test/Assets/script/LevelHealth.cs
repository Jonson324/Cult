using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]


public class LevelHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeadCamera;
    public GameObject Parent;
    public GameObject PanelDead;
    public static float levelHealth;
    public static Items mon;
   [SerializeField] public static int coin;
    public Text txt;
    public float maxhealth = 100;
    public bool start;
    public GameObject tp;
    public GameObject tp1;
    public GameObject tp2;
    public GameObject tp3;
    public GameObject tp4;
    public enamyCount enamyCount;
    
    private bool isOnDeadZone = false;
    
   
    void Start()
    {
        
        Player = gameObject;
    }

    
    void Update()
    {
       
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
           
            if (enamyCount.count == 2)
            {
                tp.SetActive(true);
                tp1.SetActive(true);

            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (enamyCount.count == 8)
            {
                tp.SetActive(true);
                tp1.SetActive(true);
                tp2.SetActive(true);
                tp3.SetActive(true);
                tp4.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (enamyCount.count == 19)
            {
                tp.SetActive(true);
                tp1.SetActive(true);
            }
        }
        if ((levelHealth > maxhealth) || (start == true))
        {
            start = false;
            levelHealth = maxhealth;
        }

        txt.text = "" + Mathf.Floor(levelHealth);

        //if (levelHealth <= 0)
        //{
        //    PanelDead.SetActive(true);
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    DeadCamera.SetActive(true);
        //    DeadCamera.transform.parent = Parent.transform;
        //    Destroy(gameObject);
        //}


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
        if (other.tag == "heal")
        {
            levelHealth = maxhealth;
        }
        if (other.tag == "money")
        {
            coin += mon.money;
            Destroy(GameObject.FindGameObjectWithTag("money"));
        }
        if (other.tag == "HealPotion")
        {
            levelHealth += 25;
            Destroy(GameObject.FindGameObjectWithTag("HealPotion"));
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
