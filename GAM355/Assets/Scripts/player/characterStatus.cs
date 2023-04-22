using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthStatusData", menuName = "StatusObjects/Health", order = 1)]
public class characterStatus : ScriptableObject
{
    public string charName = "name";
    public GameObject character;
    public int level = 1;
    public float maxHealth = 100;
    public float maxMind = 100;
    public float HP = 100;
    public float MIND = 100;

}
