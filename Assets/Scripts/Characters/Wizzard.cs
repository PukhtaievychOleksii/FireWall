using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Location {
    BattleField,
    Labaratory
}

public class Wizzard : Character
{
    Controller Controller;
    public Location CurrentLocation = Location.BattleField;
    public PotionsType CurrentShootingPotionType = PotionsType.Potion1;
    [HideInInspector]
    public Ingridient CurrentIngridient = null;
    [HideInInspector]
    public InventorySystem InventorySystem;
    private AudioSource AudioSource;
    private int ScoreKilledMonsters = 0;
    


  

    void Awake()
    {
        Controller = GetComponent<Controller>();
        AudioSource = GetComponent<AudioSource>();
        



        DataHolder.SetWizzard(this);
        InventorySystem = new InventorySystem();
        //DataHolder.SoundManager.addAudioSorceMaster(AudioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSound(float volume)
    {
        AudioSource.volume = volume;
    }
    public void UpdateScoreKilledMonsters() 
    {
        
        ScoreKilledMonsters++;
        DataHolder.UIHandler.UpadteFinalTextKilledMonsters(ScoreKilledMonsters);
    }

    public void ChangeLocation()
    {
        if (CurrentLocation == Location.BattleField)
        {
            MoveTo(Game.LabPoint.transform.position);
            CurrentLocation = Location.Labaratory;
        }
        else
        {
            MoveTo(Game.WatchPoint.transform.position);
            CurrentLocation = Location.BattleField;
        }
        DataHolder.Labaratory.RemoveIngridient();
    }
    
    public void ChangePotionShootingType(PotionsType potionType)
    {
        CurrentShootingPotionType = potionType;
    }
}
