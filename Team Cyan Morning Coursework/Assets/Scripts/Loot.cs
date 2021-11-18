using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to represent the item/loot being picked up by the player.
 */
public class Loot
{
    //Loot type: So far can be Apple or Berry.
    public Item.ItemType lootType;
    //Amount picked up.
    public int lootAmount;
}
