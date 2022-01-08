using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
   
    public void ResumeGame() {
        // i dont know how to load seen back if next seen was attachted 
        //SceneManager.LoadScene(0);
        Debug.Log("Game is resumed");
        PouseGame.SetCanvasActive();
    }
    public void GoToOptions()
    {

    }
    public void BackToMainMenu()
    {
        // not implementit seen MAIN
    }

}
