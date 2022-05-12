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
    public float Health;


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
}
