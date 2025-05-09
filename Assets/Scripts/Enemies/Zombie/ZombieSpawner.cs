using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    // make a method that takes in 4 spawn points and will check which one is closer
    
    public GameObject ZombieObject,WizardObject,GiantObject;

    public Transform SpawnPoint,SpawnPointTwo,SpawnPointThree,player;

    private Transform ClosestSpawner;

    public int NumberOfZombies,NumberOfWizards,NumberOfGiants,Round,LastRound;

    private float SpawnPointDistance,SpawnPointTwoDistance,SpawnPointThreeDistance;

    public Text RoundCounter;

    private bool WizCanSpawn,GiantCanSpawn;

    public double ZombieMarkiplier,WizardMarkiplier,giantMarkiplier;
    
    private void start()
    {
        DistanceToSpawnPoint();
        WizCanSpawn = false;
        

    }
    private void DistanceToSpawnPoint()
    {
        
       
        SpawnPointDistance = Vector3.Distance(SpawnPoint.position, player.position);
        SpawnPointTwoDistance = Vector3.Distance(SpawnPointTwo.position, player.position);
        SpawnPointThreeDistance = Vector3.Distance(SpawnPointThree.position, player.position);

        if(SpawnPointDistance < SpawnPointTwoDistance && SpawnPointDistance < SpawnPointThreeDistance )
        {
            
            ClosestSpawner = SpawnPoint;
        }
        else if(SpawnPointTwoDistance < SpawnPointDistance && SpawnPointTwoDistance < SpawnPointThreeDistance )
        {
            
            ClosestSpawner = SpawnPointTwo;
        }
        else if(SpawnPointThreeDistance < SpawnPointDistance && SpawnPointThreeDistance < SpawnPointTwoDistance  )
        {
            
            ClosestSpawner = SpawnPointThree;
        }


    }

    private void RoundMultiplier()
    {
        ZombieMarkiplier = Round * 1.5;
        if(Round >= 5)
        {
            WizCanSpawn = true;
            WizardMarkiplier = Round * .5;
        }
        if(Round >= 15)
        {
            GiantCanSpawn = true;
            giantMarkiplier = Round * .2;
        }

    }

    public void SubstractZombie()
    {
        NumberOfZombies--;
        Debug.Log($"the number of zombies is {NumberOfZombies}");
    }
    public void SubtractWizard()
    {
        NumberOfWizards--;
    }
    public void SubtractGiant()
    {
        NumberOfGiants--;
    }


    private void spawn()
    {
        
       if(!WizCanSpawn)
        {
            while(NumberOfZombies <= ZombieMarkiplier)
            {
                NumberOfZombies++;
            
                    Debug.Log(NumberOfZombies);

                         GameObject Zombie = Instantiate(ZombieObject, ClosestSpawner.position, ClosestSpawner.rotation);

                
                
            }
            
        }

        if(WizCanSpawn && !GiantCanSpawn)
        {
            while(NumberOfWizards <= WizardMarkiplier || NumberOfZombies <= ZombieMarkiplier)
            {
                if(NumberOfWizards <= WizardMarkiplier)
                {
                    GameObject WizZombie = Instantiate(WizardObject,ClosestSpawner.position, ClosestSpawner.rotation );
                    NumberOfWizards++;
                }
                if(NumberOfZombies <= ZombieMarkiplier)
                {
                     GameObject Zombie = Instantiate(ZombieObject, ClosestSpawner.position, ClosestSpawner.rotation);
                     NumberOfZombies++;
                }
                
            }
            







        }
        if(WizCanSpawn && GiantCanSpawn)
        {
            while(NumberOfGiants <= giantMarkiplier || NumberOfWizards <= WizardMarkiplier || NumberOfZombies <= ZombieMarkiplier)
            {
                if(NumberOfGiants <= giantMarkiplier)
                {
                    GameObject giantzombie = Instantiate(GiantObject, ClosestSpawner.position, ClosestSpawner.rotation );
                    NumberOfGiants++;

                }
                if(NumberOfWizards <= WizardMarkiplier)
                {
                    GameObject WizZombie = Instantiate(WizardObject,ClosestSpawner.position, ClosestSpawner.rotation );
                    NumberOfWizards++;
                }
                if(NumberOfZombies <= ZombieMarkiplier)
                {
                     GameObject Zombie = Instantiate(ZombieObject, ClosestSpawner.position, ClosestSpawner.rotation);
                     NumberOfZombies++;
                }
            }



        }

              
       
           
   }
        
       
        
        
    

      void Update()
    {
        
        RoundCounter.text = $"Round: {Round.ToString()}";
        if(NumberOfZombies == 0 && NumberOfWizards == 0 && NumberOfGiants == 0) 
        {
            
           
            if(Input.GetKey(KeyCode.E))
            {
                
                Round++;
                RoundMultiplier();
                DistanceToSpawnPoint();;
                spawn();




            }
           
            
        }
        

         
       
        
        
        

    }
}
    



    

   
   

    

    
   
    

 
       

    

    

   
    
