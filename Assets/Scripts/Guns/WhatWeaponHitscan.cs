using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatWeaponHitscan : MonoBehaviour
{
    [SerializeField] GameObject WeaponToSwitchTo;
    [SerializeField] WeaponSwitch Weaponswitch;
    
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Weaponswitch.WeaponHolder = WeaponToSwitchTo;
            Weaponswitch.StringHolder = "HitScan";
            Weaponswitch.SwitchWeapons();
            
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
