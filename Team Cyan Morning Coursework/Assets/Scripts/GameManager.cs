using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Player resources
    public Inventory playerInventory;       // Player's inventory
    public int goldAmount;      // Player's gold

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            playerInventory = new Inventory();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
