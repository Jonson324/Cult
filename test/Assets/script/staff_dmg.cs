using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff_dmg : MonoBehaviour
{
    public inDialog inDialogScript;
    public PauseMenu pauseMenuScript;
    public List<Transform> bullets = new List<Transform>();
    public float bulletSpeed = 10000;
    public List<AudioClip> sounds = new List<AudioClip>();
    public static float time_left;

    void Update()
    {
        if (time_left > 0) {
            time_left -= Time.deltaTime;
        }

        if ((pauseMenuScript.GameISPause == false) && (inDialogScript.in_dialog == false) && (time_left <= 0)) {
            if (amulet.currentCrystall != "Аква кристалл") {
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    Shot();
                }
            }
            if (amulet.currentCrystall == "Аква кристалл") {
                if (Input.GetKey(KeyCode.Mouse0)) {
                    Shot();
                }
            }
        }
    }

    void Shot() {
        Transform bulletInstance = (Transform)Instantiate(bullets[amulet.k], GameObject.Find("spawn").transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        GetComponent<AudioSource>().PlayOneShot(sounds[amulet.k]);
        time_left = amulet.cooldown;
    }
}
