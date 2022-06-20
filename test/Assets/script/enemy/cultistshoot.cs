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
    bool shootAvl;
    
    float firerate = 0.4f;
    void Start()
    {
        target = Player.transform;
        shootAvl = true;
    }

    
    void Update()
    {
        firerate -= Time.deltaTime;
        Vector3 direction =  transform.position - target.position;

        //if (shootAvl)
        //{
        //    Shoot();
        //}
        //shootAvl = false; 

        if (firerate <= 0)
        {
           
            gameObject.GetComponent<Animator>().Play("AtackCult");
            firerate = 0.4f;
            Shoot();

        }
    }
    void Shoot()
    {
        Instantiate(projectile,shootPoint.position,shootPoint.rotation);
    }
}
