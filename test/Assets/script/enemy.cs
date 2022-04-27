using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))] //������������ ��������� �������� navmeshagent � ������ ��� ���������� �������
public class enemy : MonoBehaviour
{
    public Transform Player;
    NavMeshAgent myAgent;
    public float dist;
    private float dmg;


    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(Player.transform.position, transform.position);

        //Анимация атаки
        /*
                if (Vector3.Distance(Player.transform.position, transform.position) <= 1.4f)
                {
                    GetComponent<NavMeshAgent>().enabled = false;
                }
                else
                {
                    GetComponent<NavMeshAgent>().enabled = true;
                    GetComponent<NavMeshAgent>().destination = Player.transform.position;
                }
          */
        //  if (dist < 1.5f)
        //{
        //  myAgent.enabled = false;
        //gameObject.GetComponent<Animator>().Play("attack_s");
        //}

        if (dist > 1.5f)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(Player.transform.position);
            gameObject.GetComponent<Animator>().Play("Walk");
        }
        if (dist < 1.5f)
        {
            myAgent.enabled = false;
            gameObject.GetComponent<Animator>().Play("attack_s");
        }
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jump")
        {
            gameObject.GetComponent<Animator>().Play("jump");
        }
       
    }
}