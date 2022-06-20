using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float Speed = 2f;
    public AudioSource hel;
    void Update()
    {
        if ( transform.position.y  >= 80)
        {
            Speed = -Speed;
        }

        if (transform.position.y <= 80.5)
        {
            Speed = -Speed;
        }
        Vector3 input = new Vector3(0, 1, 0);
        transform.position = transform.position + input * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hel.Play();
            Destroy(gameObject);
        }
    }
}
