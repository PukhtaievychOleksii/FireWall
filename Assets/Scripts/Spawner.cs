using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Game Game; // must be set in Unity
    public GameObject WizzardPrefab;// must be set in Unity
    public GameObject WizzardSpawnPoint;// must be set in Unity

    void Awake()
    {
        Wizzard wizzard = SpawnWizzard();
        Game.Wizzard = wizzard;
        wizzard.Game = Game;   
       
    }

    void Update()
    {
        
    }

   public Wizzard SpawnWizzard()
    {
        GameObject gameObject = Instantiate(WizzardPrefab, WizzardSpawnPoint.transform.position, Quaternion.identity);
        Wizzard wizzard = gameObject.GetComponent<Wizzard>();
        wizzard.CharacterGameObject = gameObject;
        return wizzard;
    }
}
