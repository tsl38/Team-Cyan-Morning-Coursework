using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;

    // References
    public Player player;

    // Logic
    public int apples;


    // Save state
    public void SaveState()
    {
        List<Loot> listOfItems = GameObject.Find("Player").GetComponent<Player>().playerInventory.GetListOfItems();
        string s = "";

        for (int i = 0; i < listOfItems.Count; i++)
        {
            s += listOfItems[i].sprite + "|";
            s += listOfItems[i].lootType + "|";
            s += listOfItems[i].lootAmount + "|";
        }

        PlayerPrefs.SetString("SaveState", s);
    }

    // Load state
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change player skin


        // Load player's inventory
        for (int i = 0; i < data.Length; i += 3)
        {
            //Loot tempLoot = new Loot { sprite = data[i], lootType = data[i+1], lootAmount = int.Parse(data[i+2]) };
            //GameObject.Find("Player").GetComponent<Player>().playerInventory.AddItem();
        }
    }
}
