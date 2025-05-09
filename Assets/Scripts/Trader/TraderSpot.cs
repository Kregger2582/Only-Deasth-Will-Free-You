using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderSpot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ShopMenu;
    [SerializeField] CameraLook camlook = null;
    [SerializeField] BountyCode IsQuestActiveBool;
    public bool IsInShop = false;

    void Start()
    {
        SetMenuActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !IsQuestActiveBool.returnquestbool())
        {
            camlook.camUnlock();
            SetMenuActive(true);
            IsInShop = true;
        }
        
    } 
    
    

    public bool ReturnShopBool()
    {
        return IsInShop;
    }

    public void SetMenuActive(bool state)
    {
        ShopMenu.SetActive(state);
        if(!state)
        {
            IsInShop = false;
        }
    }
   
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
            {
                camlook.camlock();
                SetMenuActive(false);
            }
    }
}
