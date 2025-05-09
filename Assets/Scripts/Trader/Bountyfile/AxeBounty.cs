using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeBounty : MonoBehaviour
{
    
    [SerializeField] DropSpawner God;
    [SerializeField] int NumberOfZombiesRequired = 0;
    [SerializeField] GameObject AxeObj;
    [SerializeField] Transform GunSpawnPoint; 
    [SerializeField] Text BountyProgress;
    [SerializeField] BountyCode isbountybool;
    [SerializeField] GameObject QuestProgressUi;

    
    void Axe()
    {
        togglequestUi(true);
        BountyProgress.text = $"{God.QuestZombiesKilled.ToString()} / {NumberOfZombiesRequired.ToString()} ";
        if(God.QuestZombiesKilled >= NumberOfZombiesRequired)
        {
            
            God.QuestZombiesKilled = 0;
            GameObject GunSpawn = Instantiate(AxeObj,GunSpawnPoint.position,GunSpawnPoint.rotation );
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
        Axe();
       
    }
}
