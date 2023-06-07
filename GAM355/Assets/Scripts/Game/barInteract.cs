using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class barInteract : MonoBehaviour  
{
    public Button interact;
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interact.gameObject.SetActive(true);

        }
       
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interact.gameObject.SetActive(false);
        }
    }
}
