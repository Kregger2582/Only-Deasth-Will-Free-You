using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
   public PlayerAttriibues PlayerHealth;
    public int Healing;
    public ZombiesAttributes IsHealthOnGround;
   private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player") && PlayerHealth.Health < 100)
        {
            
            PlayerHealth.Health+=Healing;
            Destroy(gameObject);
           
        }
        



   }
   void DestoryTheMedkit()
   {
        Destroy(gameObject);
   }

    // Update is called once per frame
    void Update()
    {
    
    }
}
