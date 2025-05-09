using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttriibues : MonoBehaviour
{
    public int Health,armor;
    private UImanager UImanager;
    public bool PlayerDied = false;
    private void Start()
    {
       
        UImanager = GetComponent<UImanager>();


    }

    public void TakeDamage(int ZomDamage)
    {
        
        Health = Health - ZomDamage;
        print($"damage taken, health is at {Health}");
        if(Health <= 0)
        {
           Death();
        }
    }
  
    void Death()
    {
        UImanager.IsDead(false);
        PlayerDied = true;
    }

    public bool PlayerDiedMethod()
    {
       
        return PlayerDied;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
