using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class to store the current and max health of the player as a list.
/*
 * Technically a useless class, this is mainly a way to trigger the event that refreshes the health bar UI. otherwise, it's a redundant class.
 * DO NOT delete this class though, otherwise health bar will not work.
 */
public class PlayerHealthList
{
    //Creates an event that will trigger when item is added to the inventory.
    public event EventHandler onHealthChange;

    private List<int> healthList; //List for storing health values.

    //Constructor.
    public PlayerHealthList() {
        healthList = new List<int>();
    }

    //Updates the health values.
    public void ChangeHealth(int current, int max) {
        healthList[0] = current;
        healthList[1] = max;

        //triggers the event. Which calls the function in Inventory_UI that refreshes the inventory UI.
        onHealthChange?.Invoke(this, EventArgs.Empty);
    }

    //Getter method that returns the list.
    public List<int> GetHealthList() {
        return healthList;
    }
}
