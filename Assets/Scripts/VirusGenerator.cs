using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public Spawner Spawner;
    public Game Game;
    private float TimeBettwenVirusesSpawn = 10f;
    private float DecrementOwerSpawnTime = 0.5f; // ower time add more monsters
    float TimeToNextVirusSpawn = 0f;


    void Start()
    {
        
    }
   

// Update is called once per frame
void Update()
    {
        if (PouseGame.GameIsPoused) return;
        TimeToNextVirusSpawn -= Time.deltaTime;
        if (TimeBettwenVirusesSpawn >= 7.5f && TimeToNextVirusSpawn < 0) // 5 monsters in 40sek
        {
            Debug.Log("Spawn 1");
            DecrementOwerSpawnTime = 0.5f;
            Spawner.SpawnVirus(Game, 60, 30, 10);
        }
        else if (TimeBettwenVirusesSpawn >= 5f && TimeToNextVirusSpawn < 0) // 10 monsters in 40sek
        {
            DecrementOwerSpawnTime = 0.25f;
            Debug.Log("Spawn 2");
            Spawner.SpawnVirus(Game, 30, 40, 30);
        }
        else if (TimeBettwenVirusesSpawn >= 2.5f && TimeToNextVirusSpawn < 0) // 20 monsters in 40sek
        {
            DecrementOwerSpawnTime = 0.05f;
            Debug.Log("Spawn 3");
            Spawner.SpawnVirus(Game, 20, 30, 50);
        }
        else if (TimeToNextVirusSpawn < 0)
        {
            DecrementOwerSpawnTime = 0f;
            Debug.Log("Spawn 4");
            Spawner.SpawnVirus(Game, 33, 33, 34);
        }

        if (TimeToNextVirusSpawn < 0)
        {
            TimeToNextVirusSpawn = TimeBettwenVirusesSpawn;

            TimeBettwenVirusesSpawn -= DecrementOwerSpawnTime;
        }
    }
}
