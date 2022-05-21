using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff_dmg : MonoBehaviour
{
    public PauseMenu pauseMenuScript;
    public inDialog inDialogScript;
    public Transform bullet;
    public float bulletSpeed = 800;
    public AudioClip Fire;

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
