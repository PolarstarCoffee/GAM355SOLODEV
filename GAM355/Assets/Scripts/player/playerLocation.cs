using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocation : MonoBehaviour
{
    public static Vector3 playerPos;
    public static playerLocation instance;

    private void Awake()
    {
        instance = this;
    }

    public void getPlayerPos() //grabs players location
    {
      playerPos= transform.position;
      DontDestroyOnLoad(transform.gameObject);
    }

    public void setPlayerPos()
    {
        transform.position = playerPos;
       
    }
}
