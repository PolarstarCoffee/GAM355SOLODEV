using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //static class makes it so this method is accessible in any way within any function. 
   public static ScenesManager instance;
    public Animator transition; //animator ref
    public float transitionTime = 1f;
    private void Awake()
    {
        instance = this;
    }

    public enum Scene //Levels are by index (mainMenu = 0, Level01 = 1, etc.. NOTE: MAKE SURE ENUM ENTRIES MATCH ORDER WITHIN UNITY'S BUILD SETTINGS, OR GAME WILL BLOW UP 
    {
        mainMenu,
        introDialogue,
        introDialogue2,
        introDialogue3,
        dungeon1,
        BattleScene,
        loseScreen,
        controls,
        credits,
        angryDialogue,
        wiseDialogue,
        barScene,
        
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
    //exits application (Only works on build)
    public void Quit()
    {
        Application.Quit();
    }
    //Duplicate scrip for dungeon load
    public void backtoGame()
    {
        SceneManager.LoadScene(Scene.dungeon1.ToString());
    }

    //loads lose screen
    public void LoadloseScreen()
    {
        SceneManager.LoadScene(Scene.loseScreen.ToString());    
    }
    public void loadControls()
    {
        SceneManager.LoadScene(Scene.controls.ToString());
    }
    //loads credits scene 
    public void loadCredits()
    {
        SceneManager.LoadScene(Scene.credits.ToString());
    }
    //loads dungeon
    public void loadDungeon()
    {
        SceneManager.LoadScene(Scene.dungeon1.ToString());
    }
    //Loads bar scene
    public void loadBar()
    {
        SceneManager.LoadScene(Scene.barScene.ToString());  
    }
    public void loadAngryNPC()
    {
        SceneManager.LoadScene(Scene.angryDialogue.ToString());
    }
    IEnumerator crossFadeTransition() //script to initiate scene transition
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Scene.BattleScene.ToString());
    }
   

    public void crossFade()
    {
        StartCoroutine(crossFadeTransition());
    }
}
