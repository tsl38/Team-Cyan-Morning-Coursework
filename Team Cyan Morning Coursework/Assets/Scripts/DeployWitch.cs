using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployWitch : MonoBehaviour
{
    public GameObject witch;
    
    private GameObject enemies;

    private void Start()
    {
        enemies = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemies.transform.childCount == 0)
        {
            witch.SetActive(true);
            Destroy(GameObject.Find("DeployWitchObj"));
        }
    }
}
