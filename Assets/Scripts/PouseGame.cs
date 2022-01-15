using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseGame : MonoBehaviour
{
    public static bool GameIsPoused = false;
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
        GameIsPoused = false;
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
        GameIsPoused = !GameIsPoused;
        EndOfGame = !EndOfGame;
    }


    public static void SetCanvasActiveOptions() 
    {
        MenuIsActiveOptions = !MenuIsActiveOptions;
        MenuIsActive = !MenuIsActive;
    }
    
    public static void SetCanvasActive()
    {
        
        GameIsPoused = !GameIsPoused;
        MenuIsActive = !MenuIsActive;
        LoadedSettings = false;




    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPoused)
        {
            //DataHolder.SoundManager.UpdateSound();

        }
        CanvasMainBaground.SetActive(GameIsPoused);
        CanvasMainManu.SetActive(MenuIsActive);
        CanvasMainManuOptions.SetActive(MenuIsActiveOptions);
        CanvasEndOfGame.SetActive(EndOfGame);



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
