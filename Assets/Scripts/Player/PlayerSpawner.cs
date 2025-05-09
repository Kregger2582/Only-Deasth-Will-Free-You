using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerSpawnPoint;
    public GameObject PlayerModel;
    public int NumOfPlayers;

    void Start()
    {
        SpawnPlayer();


        
    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerModel,PlayerSpawnPoint.position,PlayerSpawnPoint.rotation);
        NumOfPlayers++;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
