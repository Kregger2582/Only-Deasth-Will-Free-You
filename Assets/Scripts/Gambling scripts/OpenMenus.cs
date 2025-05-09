using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenus : MonoBehaviour
{
    
    bool InMenu = false;
    [SerializeField] CameraLook camlook = null;
    [SerializeField] GameObject GamblingGunScreen;
    [SerializeField] Text PlayerNumbers;
    [SerializeField] Text DealerNumbers;
    [SerializeField] Gambling gameints;
    
    void start()
    {
        GamblingGun(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GamblingGun(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("f"))
        {
            GamblingGun(false);
        }
        PlayerNumbers.text = $"Your card: {gameints.playerscard.ToString()}";
        DealerNumbers.text = $"Dealers card: {gameints.Dealerscard.ToString()}";

    }
    public void GamblingGun(bool state)
    {
        GamblingGunScreen.SetActive(state);
        InMenu = state;
         if(state)
        {
            camlook.camUnlock();
        }
        else
        {
            camlook.camlock();
        }

    }
    
    public bool ReturnIfInMenu()
    {
        return InMenu;
    }
}
