using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{
    [SerializeField] public List<Items> Rareitems;
    [SerializeField] public List<Items> items;
    public double Health;
    public enamyCount enamyCount;
    public AudioSource auddeath;
    private void Start()
    {
        if (gameObject.tag == "Cultist")
        {
            Health = 15;
        }
        if (gameObject.tag == "skelet")
        {
            Health = 25;
        }
        if(gameObject.tag == "Boss")
        {
            Health = 250;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireboll")
        {
            Health -= (amulet.damage * amulet.dmg_multiplier);
            
            if (Health <= 0)
            {                
                if (Random.Range(0, 100) > 15)
                {
                    Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity);
                }
                else if (Random.Range(0, 100) <= 15)
                {
                    Instantiate(Rareitems[Random.Range(0, items.Count)], transform.position, Quaternion.identity);
                }
                auddeath.Play();
                Destroy(gameObject);
                enamyCount.count += 1;
            }
        }
    }
}
