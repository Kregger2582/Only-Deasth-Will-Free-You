using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// need to add a way for the zombie to do damage 


public class ZombieBehiavor : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent Agent = null;
    public Transform Player;
    public float speed = 6;
    

    // Start is called before the first frame update
    void Start()
    {
        Initalize();
        ChasePlayer();
    }

    private void Initalize()
    {

        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void MoveToPlayer()
    {

        Agent.SetDestination(Player.position);
        
    }

    private void ChasePlayer()
    {
        int number = UnityEngine.Random.Range(1, 4);
        
       
        
        

        if(number == 1)
        {
            
            GetComponent<NavMeshAgent>().speed  = speed * 2;
           
        }


    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
