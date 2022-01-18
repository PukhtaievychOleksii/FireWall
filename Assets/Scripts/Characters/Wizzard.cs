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
    public AudioSource audioSource;
    public SoundEffectUpdater soundeffectUpdater;
    private int ScoreKilledMonsters = 0;
    


  

    void Awake()
    {
        Controller = GetComponent<Controller>();
        



        DataHolder.SetWizzard(this);
        InventorySystem = new InventorySystem();
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateMain(audioSource);
        //DataHolder.SoundManager.addAudioSorceMaster(AudioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPoused)
        {
            soundeffectUpdater.UpdateMain(audioSource);
            return;
        }
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
            // meaby add some w8 time
            if (DataHolder.Labaratory.Culdorn.ActiveRecepy.Count > 0)
            {
                DataHolder.Labaratory.Culdorn.SomthingInCuldron.SetActive(true);
            }
        }
        else
        {
            MoveTo(Game.WatchPoint.transform.position);
            CurrentLocation = Location.BattleField;
            DataHolder.Labaratory.Culdorn.SomthingInCuldron.SetActive(false);
        }
        DataHolder.Labaratory.RemoveIngridient();
    }
    
    public void ChangePotionShootingType(PotionsType potionType)
    {
        CurrentShootingPotionType = potionType;
    }
}
