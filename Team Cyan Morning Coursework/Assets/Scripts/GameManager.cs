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
    public int hitpoint;

    // UI Resources
    public FloatingTextManager floatingTextManager;

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

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
}
