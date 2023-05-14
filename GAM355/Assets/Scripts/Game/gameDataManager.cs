using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static gameDataManager instance;
    
    public string unitName; //name for Unit
    public int unitLevel; //Unit Level (might be arbitrary) 
    public int damage;
    public int maxHP;
    public int playerCurrentHP;
    public int currentHP;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    } //ensures object is not destroyed as scenes change


 
}
