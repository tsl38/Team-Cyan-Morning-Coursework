using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to represent the inventory of the player.
 */
public class Inventory
{
    //A list of Loot to store items picked up by the player.
    private List<Loot> listOfItems;

    //Constructor to initialize the list.
    public Inventory() {
        listOfItems = new List<Loot>();
    }

    //A function to add items to the inventory.
    public void addItem(Loot loot) {
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
            listOfItems.Add(loot);
        }
        //If item is in inventory, increase the amount.
        else
        {
            listOfItems[index].lootAmount = listOfItems[index].lootAmount + loot.lootAmount;
        }

        //Temp: Prints out the inventory list to console.
        for (int i = 0; i < listOfItems.Count; i++)
        {
            Debug.Log(listOfItems[i].lootType + ", " + listOfItems[i].lootAmount);
        }
    }
}
