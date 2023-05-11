using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; //name for Unit
    public int unitLevel; //Unit Level (might be arbitrary) 
    public int damage;
    public int maxHP;
    public int currentHP;

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
        currentHP -= dmg / 2;
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        } 
            
    }
}
