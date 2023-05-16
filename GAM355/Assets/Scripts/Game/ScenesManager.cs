using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //static class makes it so this method is accessible in any way within any function. 
   public static ScenesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Scene //Levels are by index (mainMenu = 0, Level01 = 1, etc.. NOTE: MAKE SURE ENUM ENTRIES MATCH ORDER WITHIN UNITY'S BUILD SETTINGS, OR GAME WILL BLOW UP 
    {
        mainMenu,
        introDialogue,
        dungeon1,
        BattleScene,
        loseScreen,
        AlphaEnd
    }

    // Load Scene method
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString()); //scene enum needs to be converted to string to be readable by method
    }

    //load new game method
    public void LoadNewGame() 
    {
        SceneManager.LoadScene(Scene.dungeon1.ToString());
    }


    //Load next scene method (Does so by increasing index of Unity build index by 1)
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Load previous scene method (scene index reduction)
    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Loads main menu scene 
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.mainMenu.ToString());
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void backtoGame()
    {
        SceneManager.LoadScene(Scene.dungeon1.ToString());
    }

    public void endofAlpha()
    {
        SceneManager.LoadScene(Scene.AlphaEnd.ToString());
    }
    public void LoadloseScreen()
    {
        SceneManager.LoadScene(Scene.loseScreen.ToString());    
    }
}
