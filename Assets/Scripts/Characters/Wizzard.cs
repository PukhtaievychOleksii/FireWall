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
    void Start()
    {
        Controller = GetComponent<Controller>();
        Controller.Game = Game;
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
}
