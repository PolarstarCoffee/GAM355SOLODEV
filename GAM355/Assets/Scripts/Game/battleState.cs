using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum TurnState { START, PLAYERTURN, WAITING, ENEMYTURN, WIN, DEFEAT} //game turnStates
public class battleState : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Sprite enemySprite;

    public Transform enemyStation1;
    public Transform enemyStation2;
    public Transform enemyStation3;
    public battleUI ui;
    

    Unit playerUnit;
    Unit enemyUnit;

    public battleUI playerUI;


    public TurnState turnState;
  
    void Start()
    {
        turnState = TurnState.START;
        StartCoroutine(SetupBattle());
        ui.setState();
    }

    IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab); //spawn player unit
        playerUnit = player.GetComponent<Unit>(); //grabs reference to player's Unit 

        GameObject enemy = Instantiate(enemyPrefab, enemyStation1); //spawn enemy unit at their station
        enemyUnit = enemy.GetComponent<Unit>(); //grabs ref to enemy unit

        playerUI.setHUD(playerUnit); //sets UI to our player

        yield return new WaitForSeconds(2f);

        turnState = TurnState.PLAYERTURN;
        playerAction();
    }

    IEnumerator PlayerAttack() //Damage enemy 
    {
        turnState = TurnState.WAITING;
        bool IsDead = enemyUnit.TakeDamage(playerUnit.damage);

        if (IsDead)
        {
            turnState = TurnState.WIN;
            StartCoroutine(EndBattle());
        }
        else
        {
            turnState = TurnState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        yield return new WaitForSeconds(2f);
        turnState = TurnState.ENEMYTURN; //Immediately set flag to enemy's turn 
    }

    /*
    IEnumerator playerDefend() //player defend functionality
    {
        yield return new WaitForSeconds(1f);
        turnState = TurnState.WAITING;
        playerUnit.Defend(enemyUnit.damage);
        Debug.Log(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        turnState = TurnState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    */

    IEnumerator playerFlee() //player Flee functionality 
    {
        int random = Random.Range(1, 101);
        if (random <= 10)
        {
            yield return new WaitForSeconds(1f);
            turnState = TurnState.WAITING;
            Debug.Log("Successfully Escaped");
            ScenesManager.instance.LoadLastScene();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Failed to Escape");
            turnState = TurnState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn() //logic for enemy 
    {
        //Text variable goes here
        yield return new WaitForSeconds(2f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
      
        Debug.Log(playerUnit.currentHP);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            yield return new WaitForSeconds(1f);
            Destroy(enemySprite);
            turnState = TurnState.DEFEAT;
            StartCoroutine(EndBattle());
        }
        else
        {
            turnState = TurnState.PLAYERTURN;
            PlayerAttack();
        }
        
    }


    IEnumerator EndBattle() //End battle method
    {
        yield return new WaitForSeconds(2f);
        //loads last scene 
        ScenesManager.instance.LoadLastScene();
        Debug.Log("Win");
    }
    void playerAction()
    {

    }

    public void onAttackButton()
    {
        if (turnState!= TurnState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void onFleeButton()
    {
      if (turnState!= TurnState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(playerFlee());
    }

    public void onDefendButton()
    {
        if (turnState != TurnState.PLAYERTURN)
        {
            return;
        }
        //StartCoroutine(playerDefend());
    }


}
