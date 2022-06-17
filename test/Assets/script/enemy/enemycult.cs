using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemycult : MonoBehaviour
{
    
    public Transform target;
    public Transform Player2;
    public Transform Enemyc;
    NavMeshAgent Cultist;
    public float distat;
    private float dmg;
    [SerializeField] float turnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Cultist = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distat = Vector3.Distance(Player2.transform.position, transform.position);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation, turnSpeed * Time.deltaTime);
        

        if (distat > 1.5f)
        {
         gameObject.GetComponent<Animator>().Play("AtackCult");
        }
        
    }
}
