using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Inventory playerInventory; //Inventory object.
    private PlayerHealthList healthList;
    [SerializeField] private Inventory_UI inventoryUi;
    [SerializeField] private Health_Bar_UI healthBarUI;

    private void Awake()
    {
        //Initializes the player inventory.
        playerInventory = new Inventory();
        healthList = new PlayerHealthList();
        if (inventoryUi != null)
        {
            inventoryUi.setInventory(playerInventory);
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
}