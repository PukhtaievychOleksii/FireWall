using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public Wizzard Wizzard;
    public List<Virus> Viruses = new List<Virus>();
    public Wall Wall;// must be set in Unity
    public GameObject LabPoint; // must be set in Unity
    public GameObject WatchPoint;// must be set in Unity
    public Spawner Spawner;// must be set in Unity;
    public UIHandler UIHandler;//must be set in Unity
    [HideInInspector]
    public Match Match;
   


    void Awake()
    {
        DataHolder.SetGame(this);
       
        Wizzard = Spawner.SpawnWizzard(this);
        Match = new Match();
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            DataHolder.Factory.AddPotion(PotionsType.Potion1);
            DataHolder.Factory.AddPotion(PotionsType.Potion2);
            DataHolder.Factory.AddPotion(PotionsType.Potion3);
        }
        
        DataHolder.UIHandler.UpdateStorageUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

   
}
