using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmashAttack : MonoBehaviour
{
    public bool RockSmashCanAttack;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RockSmashCanAttack = true;
            
            print("player entered");
             



        }
       






    }
    public void OnTriggerExit(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            RockSmashCanAttack = false;
            

        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
