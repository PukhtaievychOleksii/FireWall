using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public Spawner Spawner;
    public Game Game;
    float TimeBettwenVirusesSpawn = 10f;
    float TimeToNextVirusSpawn = 0f;


    void Start()
    {
        
    }
   

// Update is called once per frame
void Update()
    {
        TimeToNextVirusSpawn -= Time.deltaTime;
        if(TimeToNextVirusSpawn < 0)
        {
            TimeToNextVirusSpawn = TimeBettwenVirusesSpawn;
            Spawner.SpawnVirus(Game);
            TimeBettwenVirusesSpawn -= 0.05f; // ower time add more monsters
        }
    }
}
