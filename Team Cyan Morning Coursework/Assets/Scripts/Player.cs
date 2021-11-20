using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Inventory playerInventory; //Inventory object.
    [SerializeField] private Inventory_UI inventoryUi;

    private void Awake()
    {
        //Initializes the player inventory.
        playerInventory = new Inventory();
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
}