using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseGame : MonoBehaviour
{
    public static bool MenuIsActive = false;
    public GameObject CanvasMainManu;
   
    public static void SetCanvasActive()
    {
        MenuIsActive = !MenuIsActive;

    }

    // Update is called once per frame
    void Update()
    {
        CanvasMainManu.SetActive(MenuIsActive);
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
