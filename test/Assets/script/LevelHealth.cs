using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHealth : MonoBehaviour
{
    public inDialog inDialogScript;
    public AudioSource audiodeath;
    public AudioSource audiohit;
    public static bool isclear;
    public bool s;
    public GameObject Player;
    public roomsch roomsch;
    public GameObject DeadCamera;
    public GameObject Parent;
    public GameObject PanelDead;
    public static float levelHealth = 100;
    public static Items mon;
    [SerializeField] public static int coin;
    public Text txt;
    public static float maxhealth = 100;
    public GameObject tp;
    public GameObject tp1;
    public GameObject tp2;
    public GameObject tp3;
    public GameObject tp4;
    public enamyCount enamyCount;
    public bool dead;
    
    private bool isOnDeadZone = false;
   
    void Start()
    {        
        Player = gameObject;
    }

    
    void Update()
    {
        if (levelHealth > maxhealth) {
            levelHealth = maxhealth;
        }

        txt.text = "" + Mathf.Floor(levelHealth);

        if (levelHealth <= 0) {
            PanelDead.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dead = true;
            inDialogScript.in_dialog = true;
            DeadCamera.SetActive(true);
            DeadCamera.transform.parent = Parent.transform;
            audiodeath.Play();
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (enamyCount.count == 8)
            {
                tp.SetActive(true);
                
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (enamyCount.count == 8)
            {
                tp.SetActive(true);
                tp1.SetActive(true);
                
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (enamyCount.count == 15)
            {
                tp1.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "deadzone")
        {
            isOnDeadZone = true;
            levelHealth = levelHealth - 5 * Time.deltaTime;
            audiohit.Play();
        }

        if (other.tag == "Health")
        {
            levelHealth += 20;
            Destroy(GameObject.FindGameObjectWithTag("Health"));
        }
        if (other.tag == "sword")
        {
            levelHealth -= 25;
            audiohit.Play();
        }
        if(other.tag == "CultistAttack")
        {
            levelHealth -= 10;
            audiohit.Play();
        }
        if (other.tag == "heal")
        {
            levelHealth = maxhealth;
        }
        if (other.tag == "HealPotion")
        {
            levelHealth += 25;
            Destroy(GameObject.FindGameObjectWithTag("HealPotion"));
        }
        if (other.tag == "BossBall")
        {
            if (amulet.boss_weakened == true)
            {
                levelHealth -= 7;
            }
            else if (amulet.boss_weakened == false)
            {
                levelHealth -= 14;
            }

            audiohit.Play();
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

    public void HealthUpgrade(int x)
    {
        maxhealth += x;
    }
}
