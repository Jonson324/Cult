using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultistprojectile : MonoBehaviour
{
    [SerializeField] float damagee = 10;
    Rigidbody rb;
    [SerializeField] float speed = 20000f;
    private void Update()
    {
        Destroy(gameObject,1f);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 diractionn = target.position - transform.position;
        rb.AddForce(diractionn * speed * Time.deltaTime );
    }

    private void OnCollisionEnther(Collision collision)
    {

        

    }
}
