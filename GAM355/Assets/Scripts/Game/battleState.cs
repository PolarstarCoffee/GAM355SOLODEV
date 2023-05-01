using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, DEFEAT} //game states
public class battleState : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform enemyStation1;
    public Transform enemyStation2;
    public Transform enemyStation3;

    Unit playerUnit;
    Unit enemyUnit;

    public battleUI playerUI;


    public BattleState state;
  
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab); //spawn player unit
        playerUnit = player.GetComponent<Unit>(); //grabs reference to player's Unit 

        GameObject enemy = Instantiate(enemyPrefab, enemyStation1); //spawn enemy unit at their station
        enemyUnit = enemy.GetComponent<Unit>(); //grabs ref to enemy unit

        playerUI.setHUD(playerUnit); //sets UI to our player

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerAction();
    }

    void playerAction()
    {

    }
}
