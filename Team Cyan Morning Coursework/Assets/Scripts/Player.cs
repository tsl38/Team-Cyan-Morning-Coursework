using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Inventory playerInventory;
    private PlayerHealthList healthList;
    [SerializeField] private Inventory_UI inventoryUi;
    [SerializeField] private Health_Bar_UI healthBarUI;

    private void Awake()
    {        
        // Load the player resources
        playerInventory = GameManager.instance.playerInventory;
        gameObject.GetComponent<GoldAmount>().goldAmount = GameManager.instance.goldAmount;
        healthList = new PlayerHealthList();

        // Testing: print list of items
        List<Loot> listOfItems = GameObject.Find("Player").GetComponent<Player>().playerInventory.GetListOfItems();
        for (int i = 0; i < listOfItems.Count; i++)
        {
            Debug.Log(listOfItems[i].lootType + ", " + listOfItems[i].lootAmount);
        }
        // Initialise inventory UI
        if (inventoryUi != null)
        {
            inventoryUi.SetInventory(playerInventory);
        }
        if (healthBarUI != null)
        {
            //Sets the initial values of current health and max health.
            healthList.GetHealthList().Add(hitpoint);
            healthList.GetHealthList().Add(maxHitpoint);
            healthBarUI.SetHealthStats(healthList);
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
        GameManager.instance.goldAmount = gameObject.GetComponent<GoldAmount>().goldAmount;
    }
}