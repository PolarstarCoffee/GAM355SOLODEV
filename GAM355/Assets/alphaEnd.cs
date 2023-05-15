using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class alphaEnd : MonoBehaviour
{
    //public void OnCollisionEnter(Collision collision)
    //{
       // ScenesManager.instance.endofAlpha();
    //}
    public void OnTriggerEnter(Collider other)
    {
        ScenesManager.instance.endofAlpha();
    }
}
