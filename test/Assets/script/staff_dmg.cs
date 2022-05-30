using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff_dmg : MonoBehaviour
{
    public inDialog inDialogScript;
    public PauseMenu pauseMenuScript;
    public Transform bullet;
    public float bulletSpeed = 10000;
    public AudioClip Fire;
    AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (pauseMenuScript.GameISPause == false) && (inDialogScript.in_dialog == false))
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, GameObject.Find("spawn").transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            GetComponent<AudioSource>().PlayOneShot(Fire);            
        } 
    }
}
