using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff_dmg : MonoBehaviour
{
    public inDialog inDialog;
    public PauseMenu pauseMenu;
    public Transform bullet;
    public float bulletSpeed = 10;
    public AudioClip Fire;
    public enemy_hp enemy_Hp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (inDialog.in_dialog == false) && (pauseMenu.GameISPause == false))
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, GameObject.Find("spawn").transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            GetComponent<AudioSource>().PlayOneShot(Fire);
            
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireboll")
        {
            enemy_hp.enemy_Hp -= 5;
            Debug.Log(enemy_Hp);
            if (enemy_Hp <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
