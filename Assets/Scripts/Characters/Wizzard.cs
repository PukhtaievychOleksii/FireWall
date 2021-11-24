using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public InventorySystem InventorySystem;
    void Awake()
    {
        Controller = GetComponent<Controller>();
        DataHolder.SetWizzard(this);
        InventorySystem = new InventorySystem();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
    
    public void ChangePotionShootingType(PotionsType potionType)
    {
        CurrentShootingPotionType = potionType;
    }
}
