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


    public SoundManagerMain SM;
    public SoundManagerEfect SE;
    public GameObject CanvasMainBaground;
    public GameObject CanvasMainManu;
    public GameObject CanvasMainManuOptions;
    public GameObject CanvasEndOfGame;

    private void Start()
    {
        StartCoroutine(WaitForLoadAllObjects(1)); // Potencional mistake with loading sound efects
        Debug.Log("TUNA 1");
        
    }

    private IEnumerator WaitForLoadAllObjects(int time)
    {
        
        yield return new WaitForSeconds(time);
        Debug.Log("TUNA 2");
        SE.LoadVolume();
        SM.LoadVolume();
        DataHolder.SoundManager.UpdateSound();
    }
    public static void SetCanvasActiveEndOfGame(bool IsFromMenu)
    {
        if (IsFromMenu) return; // becouse script is used in MainMenu Scene
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
            DataHolder.SoundManager.UpdateSound();

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
