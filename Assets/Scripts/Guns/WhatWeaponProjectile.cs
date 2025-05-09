using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatWeaponProjectile : MonoBehaviour
{
    [SerializeField] GameObject WeaponToSwitchTo;
    [SerializeField] WeaponSwitch Weaponswitch;

    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Weaponswitch.WeaponHolder = WeaponToSwitchTo;
            Weaponswitch.StringHolder = "projectile";
            Weaponswitch.SwitchWeapons();
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
