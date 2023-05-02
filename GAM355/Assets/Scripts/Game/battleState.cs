using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum BattleState { START, PLAYERTURN, WAITING, ENEMYTURN, WIN, DEFEAT} //game states
public class battleState : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Sprite enemySprite;

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

    IEnumerator PlayerAttack() //Damage enemy 
    {
        state = BattleState.WAITING;
        bool IsDead = enemyUnit.TakeDamage(playerUnit.damage);

        if (IsDead)
        {
            state = BattleState.WIN;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN; //Immediately set flag to enemy's turn 
    }

    IEnumerator EnemyTurn() //logic for enemy 
    {
        //Text variable goes here
        yield return new WaitForSeconds(2f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage); 
        playerUI.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            yield return new WaitForSeconds(1f);
            Destroy(enemySprite);
            state = BattleState.DEFEAT;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.PLAYERTURN;
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
        if (state!= BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }


}
