using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
   
   
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && ControlledCharacter is Wizzard) (ControlledCharacter as Wizzard).ChangeLocation();

        if (Input.GetMouseButtonDown(0)) DataHolder.Cannon.FireOnMousePosition();

        if (Input.GetKeyDown(KeyCode.Alpha1)) DataHolder.Wizzard.ChangePotionShootingType((PotionsType)1);

        if (Input.GetKeyDown(KeyCode.Alpha2)) DataHolder.Wizzard.ChangePotionShootingType((PotionsType)2);

        if (Input.GetKeyDown(KeyCode.Alpha3)) DataHolder.Wizzard.ChangePotionShootingType((PotionsType)3);


    }
}
