using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{

    [SerializeField]
    Button startGame;
    [SerializeField]
    Button endGame;

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(StartGame);
        endGame.onClick.AddListener(EndGame);
    }   

    // Update is called once per frame
    private void StartGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    private void EndGame()
    {
        Application.Quit();
    }
}
