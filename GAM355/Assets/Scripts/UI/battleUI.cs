using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class battleUI : MonoBehaviour
{

    public TextMeshProUGUI nameText; //Player text
    public void setHUD(Unit unit) //sets our UI 
    {
        nameText.text = unit.unitName;
    }


    public void setHP(int hp)
    {

    }
}
