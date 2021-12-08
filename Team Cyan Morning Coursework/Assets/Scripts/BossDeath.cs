using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BossDeath : MonoBehaviour
{
    public GameObject doorSeal;

    private void OnDestroy()
    {
        GameObject.Find("Portal").GetComponent<Portal>().bossDead = true;
        //Disable the door seal effect if it is available.
        if (doorSeal != null)
        {
            doorSeal.GetComponent<Light2D>().enabled = false;
        }
    }
}
