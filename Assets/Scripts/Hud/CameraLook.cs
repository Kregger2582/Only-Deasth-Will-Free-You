using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    [SerializeField] PlayerAttriibues IsPlayerDead;
    [SerializeField] UImanager ui;
    [SerializeField] TraderSpot ThePad;
    [SerializeField] OpenMenus IsGamblingCheck;
    void Start()
    {
      
    }
    private void CursorLockCheck()
    {
      if(!IsPlayerDead.PlayerDiedMethod()&& !ui.Paused() && !ThePad.ReturnShopBool() && !IsGamblingCheck.ReturnIfInMenu())
      {
        camlock();
       
      }
      else
      {
        camUnlock();
        
      }

    }
    private void canLook()
    {
      if(!IsPlayerDead.PlayerDiedMethod() && !ui.Paused() && !IsGamblingCheck.ReturnIfInMenu())
      {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
      }
    }
    public void camlock()
    {
      Cursor.lockState = CursorLockMode.Locked;  
    }
    public void camUnlock()
    {
       Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
        
    }
    
    void LateUpdate()
    {
      CursorLockCheck();
      canLook();
     
    }

   
  
}