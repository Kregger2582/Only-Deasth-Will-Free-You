using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public int health,ZomDamage;

    public float range, shootforce;
    
    

    private bool attacking;

    public Transform Player,shootPoint;

    public GameObject FireBall,God,Spawner;
    // start a random class
    private int ShouldTrack;
    // if the the number is 1/10 the projectile should auto track
    void Start()
    {
       resetattack();
    }

    void resetattack()
    {
        attacking = false;
    }
    
    void CanWizShoot()
    {
        if(Vector3.Distance(Player.transform.position,shootPoint.transform.position) < range && !attacking)
        {
            FireBallShoot();
        }

        

    }

    //that will kill the wizard
    public void TakeDamage(int damage)
    {
       
        health = health - damage;
        if(health <= 0)
        {
            Spawner.GetComponent<ZombieSpawner>().SubtractWizard();
            God.GetComponent<DropSpawner>().AddZombiesKilled();
            God.GetComponent<DropSpawner>().AddQuestZombiesKilled();
            Destroy(gameObject);
        }

    }
    // if player in range and hit by line fire fireball
    void FireBallShoot()
    {
        
       

        GameObject bigballs = Instantiate(FireBall, shootPoint.position, shootPoint.rotation);
        
        
        
        Rigidbody rb = bigballs.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootforce, ForceMode.Impulse);
            
        }
        attacking = true;
        Invoke("resetattack",3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        CanWizShoot();
    }
}
