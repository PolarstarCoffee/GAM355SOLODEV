using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class battleUI : MonoBehaviour
{

    public TextMeshProUGUI nameText; //Player text
    public TextMeshProUGUI HPText; //HP text reference
    public TextMeshProUGUI enemyHP; //Enemy HP text reference 
    public TextMeshProUGUI enemyName; //enemy name text reference
    public void setHUD(Unit unit) //sets our UI 
    {
        nameText.text = unit.unitName;
        //HPText.text = gameDataManager.instance.playerCurrentHP.ToString();
    }


    public void setHP(Unit unit)
    {
        HPText.text = gameDataManager.instance.playerCurrentHP.ToString();
    }

    public void enemySetHP(Unit unit) //displays Enemy HP (5/18/23): Might need to create seperate class for enemy UI display
    {
        enemyHP.text = gameDataManager.instance.currentHP.ToString();
    }

    public void enemySetName(Unit unit) //Displays enemy name
    {
        enemyName.text = gameDataManager.instance.unitName.ToString();
    }
   
}
