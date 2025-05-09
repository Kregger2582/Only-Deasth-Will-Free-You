using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    public GameObject Player;
    public int ZomDamage,Health;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            Player.GetComponent<PlayerAttriibues>().TakeDamage(ZomDamage);
            Destroy(gameObject);

        }
        else if(!other.CompareTag("GiantZombie") && ! other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Invoke("DestroyRock",10);
    }
    void DestroyRock()
    {
        Destroy(gameObject);
    }
    
    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}




   




        

   

