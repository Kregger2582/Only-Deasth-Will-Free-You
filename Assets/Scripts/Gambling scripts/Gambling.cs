using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : MonoBehaviour
{
    [SerializeField] WeaponSwitch Weaponswitch;
    [SerializeField] OpenMenus turnoffmenu;

    bool playerwin = false;
    bool GameEnded;
    public int Dealerscard = 0;
    
    public int playerscard = 0;
    void Start()
    {
        playerscard = UnityEngine.Random.Range(2, 11);
        Dealerscard = UnityEngine.Random.Range(2, 11);
    }
    void PlayerGiveCard(int randomint)
    {
        playerscard = playerscard + randomint;
    }
    void DealerGiveCard(int randomint)
    {
        Dealerscard = Dealerscard + randomint;
    }
    public void PlayerHit()
    {
        if(playerscard <= 21 && !GameEnded)
        {
            PlayerGiveCard(UnityEngine.Random.Range(2, 11));
        }
        else if(playerscard > 21 )
        {
            playerwin = false;
            GameEnded = true;
            Results();
        }
    }
    public void Stand()
    {
        while(Dealerscard < 21 && Dealerscard < playerscard && !GameEnded )
        {
            DealerGiveCard(UnityEngine.Random.Range(2, 11));
            if(Dealerscard > 21 )
            {
                playerwin = true;
                GameEnded = true;
                Results();
                
            }
            else  if(Dealerscard > playerscard && Dealerscard <= 21 )
            {
                playerwin = false;
                GameEnded = true;
                Results();
               
            }
            else if( Dealerscard == playerscard)
            {
                TiedMatch();
            }
        }
    }
    void ResetGame()
    {
        turnoffmenu.GamblingGun(false);
        playerscard = UnityEngine.Random.Range(2, 11);
        Dealerscard = UnityEngine.Random.Range(2, 11);
    }
    void TiedMatch()
    {
        playerscard = UnityEngine.Random.Range(2, 11);
        Dealerscard = UnityEngine.Random.Range(2, 11);
    }
    void Results()
    {
        switch(Weaponswitch.currentstring)
        {
            case "projectile":
                if(playerwin)
                {
                   Weaponswitch.CurrentGun.GetComponent<Gun>().adddmg();
                }
                else
                {
                    Weaponswitch.CurrentGun.GetComponent<Gun>().subtractdmg();
                }
                break;
            case "HitScan":
                if(playerwin)
                {
                    Weaponswitch.CurrentGun.GetComponent<Hitscan>().adddmg();
                }
                else
                {
                    Weaponswitch.CurrentGun.GetComponent<Hitscan>().subtractdmg();
                }
                break;
            default:
                print(Weaponswitch.currentstring);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
       
    }
}
