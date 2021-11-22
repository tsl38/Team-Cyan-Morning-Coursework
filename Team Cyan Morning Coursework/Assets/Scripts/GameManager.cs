using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Player resources
    public Inventory playerInventory;       // Player's inventory
    public int goldAmount;      // Player's gold

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            playerInventory = new Inventory();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
