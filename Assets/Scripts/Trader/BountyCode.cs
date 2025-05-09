using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyCode : MonoBehaviour
{
    private int ButtonSelected; 
    [SerializeField] TraderSpot myPad;
    [SerializeField] CameraLook camlook = null;
    [SerializeField] GameObject AssualtBounty;
    [SerializeField] GameObject Shotgunbounty;
    [SerializeField] GameObject Flamethrowerbounty;
    [SerializeField] GameObject MagnumBounty;
    [SerializeField] GameObject AxeBounty;
    [SerializeField] GameObject SniperBounty;
    private GameObject CurrentGameObj = null;
    public bool IsQuestActive = false;
    
    void Start()
    {
        firstdisable();
    }
    void firstdisable()
    {
        AssualtBounty.SetActive(false);
        Shotgunbounty.SetActive(false);
        Flamethrowerbounty.SetActive(false);
        MagnumBounty.SetActive(false);
        AxeBounty.SetActive(false);
        SniperBounty.SetActive(false);
    }
    public void ButtonOneSelected()
    {
        ButtonSelected = 1;
        BountySwitch();
    }
     public void ButtonTwoSelected()
    {
        ButtonSelected = 2;
        BountySwitch();
    }
     public void ButtonThreeSelected()
    {
        ButtonSelected = 3;
        BountySwitch();
    }
     public void ButtonFourSelected()
    {
        ButtonSelected = 4;
        BountySwitch();
    }
     public void ButtonFiveSelected()
    {
        ButtonSelected = 5;
        BountySwitch();
    }
     public void ButtonSixSelected()
    {
        ButtonSelected = 6;
        BountySwitch();
    }
    public void TurnOffQuest(bool state)
    {
        IsQuestActive = state;
    }
    
    public bool returnquestbool()
    {
        return IsQuestActive;
    }

    public void TurnOffCurrent()
    {
        CurrentGameObj.SetActive(false);
    }

    void BountySwitch()
    {
        IsQuestActive = true;
        switch(ButtonSelected)
        {
            case 1:
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = AssualtBounty;
                AssualtBounty.SetActive(true);
                
                break;
            case 2:
                
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = Shotgunbounty;
                Shotgunbounty.SetActive(true);
                break;
            case 3:
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = Flamethrowerbounty;
                Flamethrowerbounty.SetActive(true);
                break;
            case 4:
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = MagnumBounty;
                MagnumBounty.SetActive(true);
                break;
            case 5:
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = AxeBounty;
                AxeBounty.SetActive(true);
                break;
            case 6:
                myPad.SetMenuActive(false);
                camlook.camlock();
                CurrentGameObj = SniperBounty;
                SniperBounty.SetActive(true);
                break;
                

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
