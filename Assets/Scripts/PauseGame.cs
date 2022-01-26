using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
    public static bool GameIsPaused = false;
    public static bool MenuIsActive = false;
    public static bool MenuIsActiveAdvacetOptions = false;
    public static bool MenuIsActiveOptions = false;
    private static bool LoadedSettings = false;
    private static bool EndOfGame = false;


    //public SoundManagerMain SM;
    //public SoundManagerEfect SE;
    public GameObject CanvasMainBaground;
    public GameObject CanvasMainManu;
    public GameObject CanvasMainManuOptions;
    public GameObject AdvacetOptions;
    public GameObject CanvasEndOfGame;

    private void Start()
    {
        Cursor.visible = GameIsPaused;

    }
    public static void SetCanvasDeffoult() 
    {
        GameIsPaused = false;
        MenuIsActive = false;
        MenuIsActiveOptions = false;
        MenuIsActiveAdvacetOptions = false;
        LoadedSettings = false;
        EndOfGame = false;
        //Cursor.visible = GameIsPaused;
    }
    public static void SetCanvasActiveEndOfGame(bool IsFromMenu)
    {
        //Debug.Log("SetCanvasActiveEndOfGame   BEFORE");
        if (IsFromMenu) { return; 
        //MenuIsActiveOptions = true;
        } // becouse script is used in MainMenu Scene
        //Debug.Log("SetCanvasActiveEndOfGame   AFTER");
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
    public static void SetCanvasAdvacetOptions()
    {
        MenuIsActiveOptions = !MenuIsActiveOptions;
        MenuIsActiveAdvacetOptions = !MenuIsActiveAdvacetOptions;
    }
    public static void SetCanvasActive()
    {
        
        GameIsPaused = !GameIsPaused;
        Cursor.visible = GameIsPaused;

        /*
        if (GameIsPaused == false)
        {
            Debug.Log("CURSOR OFF");
            //Cursor.visible = true;
            if (DataHolder.Wizzard.CurrentLocation == Location.BattleField) 
            { 
                Debug.Log("CURSOR OFF 1"); 
                DataHolder.BattleField.EnableBattleCursor(); 
            }
            if (DataHolder.Wizzard.CurrentLocation == Location.Labaratory)
            {
                Debug.Log("CURSOR OFF 2");
                DataHolder.Labaratory.EnableLabCursor();
            }
        }
        else
        {
            DataHolder.BattleField.DisableBattleCursor();
            DataHolder.Labaratory.DisableLabCursor();
        }*/

        MenuIsActive = !MenuIsActive;
        LoadedSettings = false;





    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            //DataHolder.SoundManager.UpdateSound();

            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        CanvasMainBaground.SetActive(GameIsPaused);
        CanvasMainManu.SetActive(MenuIsActive);
        CanvasMainManuOptions.SetActive(MenuIsActiveOptions);
        CanvasEndOfGame.SetActive(EndOfGame);
        AdvacetOptions.SetActive(MenuIsActiveAdvacetOptions);
        //Cursor.visible = GameIsPaused;

        /*if (GameIsPaused || MenuIsActive || MenuIsActiveOptions || EndOfGame)
        {
            DataHolder.BattleField.DisableBattleCursor();
            DataHolder.Labaratory.DisableLabCursor();
        }*/
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
