using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to represent the inventory of the player.
 */
public class Inventory
{
    //Creates an event that will trigger when item is added to the inventory.
    public event EventHandler onItemListChange;

    //A list of Loot to store items picked up by the player.
    private List<Loot> listOfItems;

    //Constructor to initialize the list.
    public Inventory() {
        listOfItems = new List<Loot>();
    }

    //A function to add items to the inventory.
    public bool addItem(Loot loot) {
        bool addSuccessful = false; //Loot has not been added to the inventory yet, so this is false by default.
        bool containsLoot = false; //Bool to indicate whether the item to be added is in the inventory already or not.
        int index = -1; //Index of the already added item.
        //Loops through the list and check if the item is already in the inventory.
        for (int i = 0; i < listOfItems.Count; i++)
        {
            if (listOfItems[i].lootType == loot.lootType)
            {
                containsLoot = true;
                index = i;
                break;
            }
        }
        //If item not in inventory, add it.
        if (containsLoot == false)
        {
            //Max of 6 items in inventory.
            if (listOfItems.Count < 6)
            {
                listOfItems.Add(loot);
                addSuccessful = true;
            }
        }
        //If item is in inventory, do the following.
        else
        {
            //If item is stackable, increase the amount.
            if (loot.isStackable())
            {
                listOfItems[index].lootAmount = listOfItems[index].lootAmount + loot.lootAmount;
                addSuccessful = true;
            }
            //If the item is not stackable, just add it to the inventory.
            else
            {
                //Max of 6 items in inventory.
                if (listOfItems.Count < 6)
                {
                    listOfItems.Add(loot);
                    addSuccessful = true;
                }
            }
        }

        //triggers the event. Which calls the function in Inventory_UI that refreshes the inventory UI.
        onItemListChange?.Invoke(this, EventArgs.Empty);

        //Temp: Prints out the inventory list to console.
        for (int i = 0; i < listOfItems.Count; i++)
        {
            Debug.Log(listOfItems[i].lootType + ", " + listOfItems[i].lootAmount);
        }

        return addSuccessful;
    }

    public List<Loot> getListOfItems() {
        return listOfItems;
    }
}
