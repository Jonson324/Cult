using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public Transform target;
    public Transform Player2;
    
    NavMeshAgent Boss;
    public float distat;
    private float dmg;
    [SerializeField] float turnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<NavMeshAgent>();
       // transform.Translate(-179, 18, -8);
    }

    // Update is called once per frame
    void Update()
    {
        distat = Vector3.Distance(Player2.transform.position, transform.position);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);


        if (distat > 15f)
        {

            Boss.enabled = true;
            Boss.SetDestination(Player2.transform.position);

        }
        if (distat < 15f)
        {

            Boss.enabled = false;
            

        }

    }
}
