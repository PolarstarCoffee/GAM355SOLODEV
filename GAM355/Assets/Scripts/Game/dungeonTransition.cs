using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entered");
            ScenesManager.instance.loadBar();
            Destroy(gameObject);
        }
    }
}
