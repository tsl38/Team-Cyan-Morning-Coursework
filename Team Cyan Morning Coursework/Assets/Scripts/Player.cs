using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Inventory playerInventory; //Inventory object.
    [SerializeField] private Inventory_UI inventoryUi;

    private void Awake()
    {
        // Load the player resources
        playerInventory = GameManager.instance.playerInventory;
        gameObject.GetComponent<Gold_Amount>().goldAmount = GameManager.instance.goldAmount;

        // Testing: print list of items
        List<Loot> listOfItems = GameObject.Find("Player").GetComponent<Player>().playerInventory.GetListOfItems();
        for (int i = 0; i < listOfItems.Count; i++)
        {
            Debug.Log(listOfItems[i].lootType + ", " + listOfItems[i].lootAmount);
        }
        // Initialise inventory UI
        if (inventoryUi != null)
        {
            inventoryUi.setInventory(playerInventory);
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed / 10;
        float y = Input.GetAxisRaw("Vertical") * speed / 10;

        UpdateMotor(new Vector3(x, y, 0));
    }

    // Save player's inventory to GameManager
    public void SavePlayer()
    {
        GameManager.instance.playerInventory = playerInventory;
        GameManager.instance.goldAmount = gameObject.GetComponent<Gold_Amount>().goldAmount;
    }
}