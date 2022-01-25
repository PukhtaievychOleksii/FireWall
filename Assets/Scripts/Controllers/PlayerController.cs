using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Controller
{
    public GameObject activeEffect;

    void Start()
    {
        activeEffect = GameObject.Find("ActivePotionEffect");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame.GameIsPaused && PauseGame.MenuIsActiveOptions)
            {
                PauseGame.SetCanvasActiveOptions();
                return;
            }
            
            PauseGame.SetCanvasActive();
            
        }
        if (PauseGame.GameIsPaused) return;
        

        if (Input.GetKeyDown(KeyCode.Tab) && ControlledCharacter is Wizzard) (ControlledCharacter as Wizzard).ChangeLocation();

        if (Input.GetMouseButtonDown(0))
        {
            if (DataHolder.Wizzard.CurrentLocation == Location.BattleField)
            {
                DataHolder.Cannon.FireOnMousePosition();
            } else
            {
                IngridientSource ingridientSource =  DataHolder.Labaratory.TryGetIngridientSource();
                ingridientSource?.GiveIngridient();
                IngridientsCook ingridientCook = DataHolder.Labaratory.TryGetIngridientCook();
                ingridientCook?.TryGetIngridient();
                if (DataHolder.Labaratory.Culdorn.IsMouseOver)
                {
                    DataHolder.Labaratory.Culdorn.TryGetIngridient();
                }

                if (DataHolder.Labaratory.Trash.IsMouseOver)
                {
                    DataHolder.Labaratory.Trash.TryDeleteIngridient();
                }
                DataHolder.Labaratory.LabCursor.GetComponent<LabCursor>().StartMagicEffect();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (DataHolder.Labaratory.Culdorn.IsMouseOver)
            {
                if (Cauldron.IsPoopOccupide) return;
                DataHolder.Labaratory.Culdorn.RemoveRecepy();
                DataHolder.Labaratory.Culdorn.GiveReadyIngridientPoop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DataHolder.Wizzard.ChangePotionShootingType((PotionsType)1);
            activeEffect.GetComponent<Transform>().position = new Vector3(-7.14f, 2.58f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DataHolder.Wizzard.ChangePotionShootingType((PotionsType)2);
            activeEffect.GetComponent<Transform>().position = new Vector3(-7.14f, -0.95f, 0f); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DataHolder.Wizzard.ChangePotionShootingType((PotionsType)3);
            activeEffect.GetComponent<Transform>().position = new Vector3(-7.14f, -4.44f, 0f);
        }


        
        


    }
}
