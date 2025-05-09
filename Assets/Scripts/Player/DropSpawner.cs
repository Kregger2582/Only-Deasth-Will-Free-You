using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int ZombiesKilled;

    public int QuestZombiesKilled;

    [SerializeField] BountyCode isbountybool;
    
    public void AddZombiesKilled()
    {
        if(ZombiesKilled < 10)
        {
            ZombiesKilled++;
        }
        
    }

    public void AddQuestZombiesKilled()
    {
        if(isbountybool.returnquestbool())
        {
            QuestZombiesKilled++;
        }
       
    }
    
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
