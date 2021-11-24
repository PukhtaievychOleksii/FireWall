using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Game Game; // must be set in Unity
    public GameObject WizzardPrefab;// must be set in Unity
    public GameObject VirusPrefab; // normal
    public GameObject VirusPrefab1; // speedy
    public GameObject VirusPrefab2; // 2helth & speed > normal && speed < speedy
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
    public GameObject GetPrefab()
    {
        var random_virus = Random.Range(1, 4);
        GameObject prefab = null;
        switch (random_virus)
        {
            case 1:
                prefab = VirusPrefab;
                break;

            case 2:
                prefab = VirusPrefab1;
                break;

            case 3:
                prefab = VirusPrefab2;
                break;

            default:
                prefab = VirusPrefab;
                break;
        }
        return prefab;
    }

    public Virus SpawnVirus(Game game)
    {
        var random_position = new Vector3(VirusSpawnPoint.transform.position.x, Random.Range(-4.5f, 4f), VirusSpawnPoint.transform.position.z);
       
        

        GameObject gameObject = Instantiate(GetPrefab(), random_position, Quaternion.identity);
        Virus virus = gameObject.GetComponent<Virus>();
        virus.CharacterGameObject = gameObject;
        virus.Game = game;
        return virus;
    }

   
}
