using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject slot1,slot2,WeaponHolder;
    public string StringHolder, currentstring;
    private string slot1string,slot2string;
    public GameObject CurrentGun;
    void Start()
    {
        slot1string = "HitScan";
        slot2string = "slot2";
        
        CurrentGun = slot1;
        WeaponHolder.SetActive(false);
    }
    void EquipOne()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        CurrentGun = slot1;
        currentstring = slot1string;
        
        
    }
    void EquipTwo()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        
        CurrentGun = slot2;
        currentstring = slot2string;
        
        
    }
    
    public void SwitchWeapons()
    {
        if(CurrentGun == slot1)
        {
            slot1.SetActive(false);
            slot1 = WeaponHolder;
           // Debug.Log("StringHolder value at time of switching: " + StringHolder);
            slot1string = StringHolder;
            slot1.SetActive(true);

        }
        else if(CurrentGun == slot2)
        {
            slot2.SetActive(false);
            slot2 = WeaponHolder;
            //Debug.Log("StringHolder value at time of switching: " + StringHolder);
            slot2string = StringHolder;
            slot2.SetActive(true);
        }
       
    }
    
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            EquipOne();
        }
        if(Input.GetKeyDown("2"))
        {
            EquipTwo();
        }
        
        
        
    }
}

    