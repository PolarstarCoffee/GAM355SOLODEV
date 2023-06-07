using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class angryNPC : MonoBehaviour
{
    public TextMeshProUGUI interact;
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            interact.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                ScenesManager.instance.loadAngryNPC();
            }
            else
            {
                return;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        interact.gameObject.SetActive(false);
    }
}
