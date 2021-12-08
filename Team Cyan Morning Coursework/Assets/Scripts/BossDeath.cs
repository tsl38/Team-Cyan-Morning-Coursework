using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject.Find("Portal").GetComponent<Portal>().bossDead = true;
    }
}
