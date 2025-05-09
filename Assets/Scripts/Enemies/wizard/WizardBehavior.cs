using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardBehavior : MonoBehaviour
{
    
    private UnityEngine.AI.NavMeshAgent Agent = null;
    public Transform Player;
    public float speed = 6;
    

    
    void Start()
    {
        Initalize();
       
    }

    private void Initalize()
    {

        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void MoveToPlayer()
    {

        Agent.SetDestination(Player.position);
        
    }

   

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
