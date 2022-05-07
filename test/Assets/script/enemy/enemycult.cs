using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemycult : MonoBehaviour
{
    public Transform Player2;
    public Transform Enemyc;
    NavMeshAgent Cultist;
    public float distat;
    private float dmg;
    // Start is called before the first frame update
    void Start()
    {
        Cultist = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distat = Vector3.Distance(Player2.transform.position, transform.position);



        if (distat > 1.5f)
        {
            Enemyc.LookAt(Player2);
            gameObject.GetComponent<Animator>().Play("AtackCult");
        }
        
    }
}
