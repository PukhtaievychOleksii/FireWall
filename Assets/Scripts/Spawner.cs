using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Game Game; // must be set in Unity
    public GameObject WizzardPrefab;// must be set in Unity
    public GameObject VirusPrefab;
    public GameObject WizzardSpawnPoint;// must be set in Unity
    public GameObject VirusSpawnPoint;

    void Awake()
    {
       
       
    }

    void Update()
    {
        
    }
    //TODO:Generic Spawn func
   public Wizzard SpawnWizzard( Game Game)
    {
        GameObject gameObject = Instantiate(WizzardPrefab, WizzardSpawnPoint.transform.position, Quaternion.identity);
        Wizzard wizzard = gameObject.GetComponent<Wizzard>();
        wizzard.CharacterGameObject = gameObject;
        wizzard.Game = Game;
        return wizzard;
    }

    public Virus SpawnVirus(Game game)
    {
        GameObject gameObject = Instantiate(VirusPrefab, VirusSpawnPoint.transform.position, Quaternion.identity);
        Virus virus = gameObject.GetComponent<Virus>();
        virus.CharacterGameObject = gameObject;
        virus.Game = game;
        return virus;
    }

   
}
