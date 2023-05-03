using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocation : MonoBehaviour
{
    public static Vector3 playerPos;


    public void getPlayerPos() //grabs players location
    {
      playerPos= transform.position;
      DontDestroyOnLoad(this.gameObject);
    }
}
