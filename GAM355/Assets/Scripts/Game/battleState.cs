using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public enum TurnState { START, PLAYERTURN, WAITING, ENEMYTURN, VICTORY, DEFEAT, DEFENDING, FLEEING, NOESCAPE, FLED} //game turnStates
public class battleState : MonoBehaviour
{
    //References
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Sprite enemySprite;

    public Transform enemyStation1;
    public Transform enemyStation2;
    public Transform enemyStation3;
    public TextMeshProUGUI stateText; //UI Reference
   


    Unit playerUnit; 
    Unit enemyUnit;

    public battleUI playerUI;
    public battleUI enemyUI;

    public TurnState turnState;
  
    void Start()
    {
        
        turnState = TurnState.START;
        StartCoroutine(SetupBattle());
        setState();
        Debug.Log(gameDataManager.instance.playerCurrentHP);
    }

    IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab); //spawn player unit
        playerUnit = player.GetComponent<Unit>(); //grabs reference to player's Unit 

        GameObject enemy = Instantiate(enemyPrefab, enemyStation1); //spawn enemy unit at their station
        enemyUnit = enemy.GetComponent<Unit>(); //grabs ref to enemy unit

        playerUI.setHUD(playerUnit); //sets UI to our player
        playerUI.setHP(playerUnit);
        playerUI.enemySetHP(enemyUnit);

        yield return new WaitForSeconds(1f);

        turnState = TurnState.PLAYERTURN;
        setState();
        playerAction();
    }

    IEnumerator PlayerAttack() //Damage enemy 
    {
        turnState = TurnState.WAITING;
        setState();
        bool IsDead = enemyUnit.TakeDamage(playerUnit.damage);
        Debug.Log(enemyUnit.currentHP);

        if (IsDead)
        {
            turnState = TurnState.VICTORY;
            setState();
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


    IEnumerator playerFlee() //player Flee functionality 
    {
     
        int random = Random.Range(1, 101);
        if (random <= 10)
        {
            yield return new WaitForSeconds(2f);
            turnState = TurnState.FLEEING;
            setState();
            yield return new WaitForSeconds(2f);
            turnState = TurnState.FLED;
            setState();
            Debug.Log("Successfully Escaped");
            yield return new WaitForSeconds(2f);
            ScenesManager.instance.LoadLastScene();
        }
        else
        {
            turnState = TurnState.FLEEING;
            setState();
            yield return new WaitForSeconds(2f);
            turnState = TurnState.NOESCAPE;
            setState();
            yield return new WaitForSeconds(3f);
            Debug.Log("Failed to Escape");
            turnState = TurnState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
            setState();
        }
    }

    IEnumerator EnemyTurn() //logic for enemy 
    {
        
        setState();
        yield return new WaitForSeconds(2f);
        bool isDead = playerUnit.PlayerTakeDamage(enemyUnit.damage);
        Debug.Log(playerUnit.playerCurrentHP);
        gameDataManager.instance.playerCurrentHP = playerUnit.playerCurrentHP; //MAKE SURE TO UPDATE GAME DATA ONCE ATTACK IS DONE
        playerUI.setHP(playerUnit);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            yield return new WaitForSeconds(1f);
            Destroy(enemySprite);
            turnState = TurnState.DEFEAT;
            setState();
            StartCoroutine(Defeat());
        }
        else
        {
            turnState = TurnState.PLAYERTURN;
            setState();
            PlayerAttack();
        }
    }
    IEnumerator EnemyDefendAttack()
    {
        turnState = TurnState.DEFENDING;
        setState();
        yield return new WaitForSeconds(2f);
        Debug.Log(playerUnit.currentHP);
        bool isDead = playerUnit.Defend(enemyUnit.damage);
        gameDataManager.instance.playerCurrentHP = playerUnit.playerCurrentHP; //MAKE SURE TO UPDATE GAME DATA ONCE ATTACK IS DONE
        playerUI.setHP(playerUnit);
        if (isDead)
        {
            yield return new WaitForSeconds(1f);
            Destroy(enemySprite);
            turnState = TurnState.DEFEAT;
            setState();
            StartCoroutine(Defeat());
        }
        else
        {
            turnState = TurnState.PLAYERTURN;
            setState();
            PlayerAttack();
        }
    } //logic for Player defense agaisnt enemyattack
    IEnumerator Defeat() //End battle method
    {
        yield return new WaitForSeconds(2f);
        setState();
        //loads last scene 
        ScenesManager.instance.LoadloseScreen();
        Debug.Log("Lost");
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
    } //attack button functionality

    public void onFleeButton()
    {
      if (turnState!= TurnState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(playerFlee());
    } //Flee button functionality 

    public void onDefendButton()
    {
        if (turnState != TurnState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(EnemyDefendAttack());
    } //Defend Button functionality 
     public void setState() //displays state on Player UI
    {
        stateText.text = turnState.ToString();
    }
    


}
