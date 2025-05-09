using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesAttributes : MonoBehaviour
{
    public int health,armor,ZomDamage,ZombieAttackTime;

    public DropSpawner DropSpawner;

    public Transform player,attacker,Spawner,GOD;

    public float range = 5;

    private bool CanZombieAttack;

    public bool HealthOnGround = false;
    
    public GameObject HealthPack;

    
    private void Awake()
    {
        MakeZombieAttack();
        

    }
   
    void MakeZombieAttack()
    {
        CanZombieAttack = true;
       
    }

    public void TakeDamage(int damage)
    {
        

        health = health - damage;
        
       
        
        
        
        //if health hits zero delete zombie, need to find a way to subtract from the number of zombies varibles
        if(health <= 0)
        {
            if(DropSpawner.ZombiesKilled == 10 && HealthOnGround == false)
            {
                HealthOnGround = true;
               
                DropSpawner.ZombiesKilled = 0;
                GameObject SpawnHealthPack = Instantiate(HealthPack,attacker.position,attacker.rotation );
            }
            GOD.GetComponent<DropSpawner>().AddZombiesKilled();
            GOD.GetComponent<DropSpawner>().AddQuestZombiesKilled();
            Spawner.GetComponent<ZombieSpawner>().SubstractZombie();
            Destroy(gameObject);
            
        }

        
    }

   
    private void DealDamage()
    {
        CanZombieAttack = false;
      
        player.GetComponent<PlayerAttriibues>().TakeDamage(ZomDamage);
        Invoke("MakeZombieAttack",3);
        



    } 

    void DrawLine()
    {
        if(Vector3.Distance(player.transform.position, player.transform.position) < 2.0)
        {
            transform.LookAt(player);

        }
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position,transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position,transform.TransformDirection(direction * range));

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Player" && CanZombieAttack == true)
            {
                
                
                DealDamage();
                
            }


        }
    }    


        



    

    // Update is called once per frame
    void Update()
    {
        
       DrawLine();
       
       

       
       
    }
}
