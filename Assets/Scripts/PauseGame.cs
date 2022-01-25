using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
    public static bool GameIsPaused = false;
    public static bool MenuIsActive = false;
    public static bool MenuIsActiveOptions = false;
    private static bool LoadedSettings = false;
    private static bool EndOfGame = false;


    //public SoundManagerMain SM;
    //public SoundManagerEfect SE;
    public GameObject CanvasMainBaground;
    public GameObject CanvasMainManu;
    public GameObject CanvasMainManuOptions;
    public GameObject CanvasEndOfGame;

    private void Start()
    {
       
        
    }
    public static void SetCanvasDeffoult() 
    {
        GameIsPaused = false;
        MenuIsActive = false;
        MenuIsActiveOptions = false;
        LoadedSettings = false;
        EndOfGame = false;
}
    public static void SetCanvasActiveEndOfGame(bool IsFromMenu)
    {
        Debug.Log("SetCanvasActiveEndOfGame   BEFORE");
        if (IsFromMenu) { return; 
        MenuIsActiveOptions = true;
        } // becouse script is used in MainMenu Scene
        Debug.Log("SetCanvasActiveEndOfGame   AFTER");
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused == false)
        {
            if(DataHolder.Wizzard.CurrentLocation == Location.BattleField) DataHolder.BattleField.EnableBattleCursor();
            if (DataHolder.Wizzard.CurrentLocation == Location.Labaratory) DataHolder.Labaratory.EnableLabCursor();
        }
        EndOfGame = !EndOfGame;
    }


    public static void SetCanvasActiveOptions() 
    {
        MenuIsActiveOptions = !MenuIsActiveOptions;
        MenuIsActive = !MenuIsActive;
    }
    
    public static void SetCanvasActive()
    {
        
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused == false)
        {
            if (DataHolder.Wizzard.CurrentLocation == Location.BattleField) DataHolder.BattleField.EnableBattleCursor();
            if (DataHolder.Wizzard.CurrentLocation == Location.Labaratory) DataHolder.Labaratory.EnableLabCursor();
        }
        MenuIsActive = !MenuIsActive;
        LoadedSettings = false;




    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            //DataHolder.SoundManager.UpdateSound();

        }
        else
        {

        }
        CanvasMainBaground.SetActive(GameIsPaused);
        CanvasMainManu.SetActive(MenuIsActive);
        CanvasMainManuOptions.SetActive(MenuIsActiveOptions);
        CanvasEndOfGame.SetActive(EndOfGame);
        if (GameIsPaused || MenuIsActive || MenuIsActiveOptions || EndOfGame)
        {
            DataHolder.BattleField.DisableBattleCursor();
            DataHolder.Labaratory.DisableLabCursor();
        }
        //else if (DataHolder.BattleField.BattleCursorObject.active == false) DataHolder.BattleField.EnableBattleCursor();


        /*if (MenuIsActive)
        {
            Time.timeScale = 1f;
            Debug.Log("SOM TUNA");
        }
        else 
        {
            Time.timeScale = 0f;
        }*/

    }

  


}
