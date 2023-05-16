using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; //name for Unit
    public int unitLevel; //Unit Level (might be arbitrary) 
    public int damage;
    public int maxHP;
    public int playerCurrentHP;
    public int currentHP;


    private void Start()
    {
     if (gameDataManager.instance != null)
        {
            playerCurrentHP = gameDataManager.instance.playerCurrentHP;
        }
    }
   

    public bool TakeDamage (int dmg) //allows enemy to take damage
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Defend (int dmg) //allows Unit to defend themselves
    {
        playerCurrentHP -= dmg / 2;
        if (playerCurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        } 
            
    }
    public void savePlayerData() //saves player data so it persists between the scenes (Moves this scripts data towards "gameDataManager")
    {
        gameDataManager.instance.unitName = unitName;
        gameDataManager.instance.unitLevel = unitLevel;
        gameDataManager.instance.damage = damage;
        gameDataManager.instance.maxHP = maxHP;
        gameDataManager.instance.playerCurrentHP = playerCurrentHP;
    } 
    public bool PlayerTakeDamage(int dmg) //allows enemy to take damage
    {
        playerCurrentHP -= dmg;

        if (playerCurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

  
}
