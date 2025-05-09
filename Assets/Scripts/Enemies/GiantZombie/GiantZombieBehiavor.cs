using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantZombieBehiavor : MonoBehaviour
{
    public Transform Player,attacker,Spawner,shootPoint,God;
    
    public int Health,ZomDamage,shootforce;

    private bool AlreadySmashed,AlreadyThrew;

    public RockSmashAttack RockSmash;

    public GameObject Rock;

    
    public void Start()
    {
        resetRock();
        resetSmash();
    }

    void resetRock()
    {
        AlreadyThrew = false;
       
    }
    void resetSmash()
    {
        AlreadySmashed = false;
        
    }
    


    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        

        if(Health <= 0)
        {
            Spawner.GetComponent<ZombieSpawner>().SubtractGiant();
            God.GetComponent<DropSpawner>().AddZombiesKilled();
            God.GetComponent<DropSpawner>().AddQuestZombiesKilled();
            Destroy(gameObject);

        }

    }
    public void ThrowRock()
    {
        //int ZombieCanThrowRock = UnityEngine.Random.Range(1,5);
        
        if(Vector3.Distance(Player.transform.position,attacker.transform.position) >= 20 && !AlreadyThrew )
        {
            AlreadyThrew = true;
            transform.LookAt(Player);
             GameObject bigrock = Instantiate(Rock, shootPoint.position, shootPoint.rotation);
        
        
        
            Rigidbody rb = bigrock.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootPoint.forward * shootforce, ForceMode.Impulse);
            
            }
            
            Invoke("resetRock",7);
            


        }





    }
    public void DealDamageRockSmash()
    {

        if(RockSmash.RockSmashCanAttack && !AlreadySmashed)
        {
            AlreadySmashed = true;
            

            
            Player.GetComponent<PlayerAttriibues>().TakeDamage(ZomDamage);
            Invoke("resetSmash", 10);

        }



    }
    

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Vector3.Distance(Player.transform.position,attacker.transform.position));
        DealDamageRockSmash();
        ThrowRock();
    }

    
}
