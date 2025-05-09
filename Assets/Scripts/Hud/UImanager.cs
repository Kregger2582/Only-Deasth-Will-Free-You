using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private bool Ispaused = false;
    
   [SerializeField]private GameObject HudCanvens = null;
   [SerializeField]private GameObject DeathCanvens = null;
    [SerializeField]private GameObject PauseCanvens = null;
    [SerializeField] private AssultBounty assultui;
    public TraderSpot inshopcheck = null;
    public OpenMenus IsGamblingCheck;

    public CameraLook camlook = null;
    private void Start()
    {
        PauseCanvens.SetActive(false);
        IsDead(true);
        assultui.togglequestUi(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Ispaused && !inshopcheck.ReturnShopBool() )
        {
            Pause(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Ispaused)
        {
            Pause(false);
        }
        
    }

   public void IsDead(bool state)
   {
        HudCanvens.SetActive(state);
        DeathCanvens.SetActive(!state);
       
    }
    public void Pause(bool state)
    {
        Ispaused = state;
        PauseCanvens.SetActive(state);
        HudCanvens.SetActive(!state);
        Time.timeScale = state ? 0 : 1;
        if(state)
        {
            camlook.camUnlock();
        }
        else
        {
            camlook.camlock();
        }
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public bool Paused()
    {
        return Ispaused;

    }
   
}
