using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    public void ResumeGame() {
        PauseGame.SetCanvasActive();
        Cursor.visible = false;
        
    }
    public void GoToOptions()
    {
        PauseGame.SetCanvasActiveOptions();
        
    }
    public void GoToAdvacet()
    {
        PauseGame.SetCanvasAdvacetOptions();

    }
    public void RetryGame(bool WitchMenu)
    {
        SceneManager.LoadScene(1); // theis needs to be chaneged later if we will make new sceens
        // meaby here shoud be some aditional destructions of IngredientType prefabs like bowls etc..
        PauseGame.SetCanvasActiveEndOfGame(WitchMenu);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        PauseGame.SetCanvasActiveEndOfGame(false);
        PauseGame.SetCanvasDeffoult();
    }
    public void ApplicationQuitGame() 
    {
        Application.Quit(); // we have to test it i dont know if it will work in production version
    }

}
