using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class BossAI : MonoBehaviour
{
    public Transform target;
    public Transform Player2;
    public enemy_hp hp;
    public GameObject spawner;
    NavMeshAgent Boss;
    public enamyCount count;
    public float distat;
    bool att;
    private float dmg;
   public AudioSource uwd;
    public static bool deth;
    
    [SerializeField] float turnSpeed = 5;
    float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<NavMeshAgent>();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        distat = Vector3.Distance(Player2.transform.position, transform.position);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
        //transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y > 17)
        {
            speed = 0;
        }

       
         if (hp.Health <= 250){
            uwd.Play();
            if (count.count == 0)
            {
               
                Spawn();
                
            }
            else if(count.count == 6) {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<Animator>().Play("Attack_B");
                gameObject.GetComponent<BossShot>().enabled = true;
                Boss.enabled = true;
                
            }
        }
         
        //if (hp.Health <= 250 )
        //{
        //    Spawn();
            
        //}
        //if (count.count == 6)
        //{
        //    Boss.enabled = true;
        //    gameObject.GetComponent<Animator>().Play("Attack_B");
        //    gameObject.GetComponent<BossShot>().enabled = true;
        //}
        if (distat > 15f)
        {

            Boss.enabled = true;
            Boss.SetDestination(Player2.transform.position);
            transform.Translate(0, speed * Time.deltaTime, 0);
            
        }
        if (distat < 15f)
        {

            Boss.enabled = false;

          
        }
        if (distat < 3f)
        {

            gameObject.GetComponent<BossShot>().enabled = false;
            gameObject.GetComponent<Animator>().Play("Attack2_B");

        }
        else if (distat > 3)
        {
            gameObject.GetComponent<BossShot>().enabled = true;
            gameObject.GetComponent<Animation>().Stop("Attack2_B");
        }
        void Spawn()
        {
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<BossShot>().enabled = false;
            gameObject.GetComponent<Animator>().Play("skell_call");
            spawner.SetActive(true);
            Boss.enabled = false;

        }
       
    }
}
