using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameThrowerBounty : MonoBehaviour
{
    
    [SerializeField] DropSpawner God;
    [SerializeField] int NumberOfZombiesRequired = 0;
    [SerializeField] GameObject FlameThrowerObj;
    [SerializeField] Transform GunSpawnPoint; 
    [SerializeField] Text BountyProgress;
    [SerializeField] BountyCode isbountybool;
    [SerializeField] GameObject QuestProgressUi;

    
    void FlmaeThower()
    {
        togglequestUi(true);
        BountyProgress.text = $"{God.QuestZombiesKilled.ToString()} / {NumberOfZombiesRequired.ToString()} ";
        if(God.QuestZombiesKilled >= NumberOfZombiesRequired)
        {
            
            God.QuestZombiesKilled = 0;
            GameObject GunSpawn = Instantiate(FlameThrowerObj,GunSpawnPoint.position,GunSpawnPoint.rotation );
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
        FlmaeThower();
       
    }
}
