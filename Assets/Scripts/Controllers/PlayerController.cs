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
    }
}
