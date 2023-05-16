using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class battleUI : MonoBehaviour
{

    public TextMeshProUGUI nameText; //Player text
    public TextMeshProUGUI HPText; //HP text reference
    
    public void setHUD(Unit unit) //sets our UI 
    {
        nameText.text = unit.unitName;
        //HPText.text = gameDataManager.instance.playerCurrentHP.ToString();
    }


    public void setHP(Unit unit)
    {
        HPText.text = gameDataManager.instance.playerCurrentHP.ToString();
    }
   
}
