using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterManager : MonoBehaviour
{
    // Start is called before the first frame update
  public static characterManager instance;
   public Vector3 playerPos;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
