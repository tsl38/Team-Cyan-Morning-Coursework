using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> listOfItems;

    public Inventory() {
        listOfItems = new List<Item>();

        Debug.Log("Inventory");
    }
}
