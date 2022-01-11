using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    public void ResumeGame() {
        PouseGame.SetCanvasActive();
    }
    public void GoToOptions()
    {
        PouseGame.SetCanvasActiveOptions();
        
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(0); // theis needs to be chaneged later if we will make new sceens
        // meaby here shoud be some aditional destructions of IngredientType prefabs like bowls etc..
        PouseGame.SetCanvasActiveEndOfGame();
    }
    public void BackToMainMenu()
    {
        Debug.Log("Game is Quit");
    }

}
