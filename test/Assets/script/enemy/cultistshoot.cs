using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultistshoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform target;
    
    [SerializeField] Transform shootPoint;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] Transform Player;
    float firerate = 0.9f;
    void Start()
    {
        target = Player.transform;
    }

    
    void Update()
    {
        firerate -= Time.deltaTime;
        Vector3 direction =  transform.position - target.position;
       
        if (firerate <= 0)
        {
            firerate = 1.8f;
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectile,shootPoint.position,shootPoint.rotation);
    }
}
