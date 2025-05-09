using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperBounty : MonoBehaviour
{
    
    [SerializeField] DropSpawner God;
    [SerializeField] int NumberOfZombiesRequired = 0;
    [SerializeField] GameObject SniperObj;
    [SerializeField] Transform GunSpawnPoint; 
    [SerializeField] Text BountyProgress;
    [SerializeField] BountyCode isbountybool;
    [SerializeField] GameObject QuestProgressUi;

    
    void Sniper()
    {
        togglequestUi(true);
        BountyProgress.text = $"{God.QuestZombiesKilled.ToString()} / {NumberOfZombiesRequired.ToString()} ";
        if(God.QuestZombiesKilled >= NumberOfZombiesRequired)
        {
            
            God.QuestZombiesKilled = 0;
            GameObject GunSpawn = Instantiate(SniperObj,GunSpawnPoint.position,GunSpawnPoint.rotation );
            isbountybool.TurnOffCurrent();
            isbountybool.TurnOffQuest(false);
            togglequestUi(false);
        }
    }
    public void togglequestUi(bool state)
    {
        QuestProgressUi.SetActive(state);
    }
    
    
    void Update()
    {
        Sniper();
       
    }
}
