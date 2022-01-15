using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Game Game; // must be set in Unity
    public GameObject WizzardPrefab;// must be set in Unity
    public GameObject VirusPrefab1;
    public GameObject VirusPrefab2;
    public GameObject VirusPrefab3;
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

    public GameObject GetGameObjectVirus( int PurpleMonsterChance, int GreenMonsterChance, int BlueMonsterChance) {
        {
            int random_virus = Random.Range(1, 100);
            GameObject prefab = null;
            if (random_virus <= PurpleMonsterChance)
            {
                prefab = VirusPrefab1;
            }
            else if ((random_virus > PurpleMonsterChance) && (random_virus <= (PurpleMonsterChance + GreenMonsterChance)))
            {
                prefab = VirusPrefab2;
            }
            else {
                prefab = VirusPrefab3;
            }
            /*switch (random_virus)
            {
                case (random_virus <= PurpleMonsterChance):
                    prefab = VirusPrefab1;
                    break;

                case 2:
                    prefab = VirusPrefab2;
                    break;

                case 3:
                    prefab = VirusPrefab3;
                    break;

                default:
                    prefab = VirusPrefab1;
                    break;
            }*/
            return prefab;
        }
    }
    public Virus SpawnVirus(Game game, int PurpleMonsterChance, int GreenMonsterChance, int BlueMonsterChance)
    {
        var random_position = new Vector3(VirusSpawnPoint.transform.position.x, Random.Range(-4.5f, 4f), VirusSpawnPoint.transform.position.z);
        GameObject gameObject = Instantiate(GetGameObjectVirus(PurpleMonsterChance, GreenMonsterChance, BlueMonsterChance), random_position, Quaternion.identity);
        Virus virus = gameObject.GetComponent<Virus>();
        virus.CharacterGameObject = gameObject;
        virus.Game = game;
        return virus;
    }

   
}
