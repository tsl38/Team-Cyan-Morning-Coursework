using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to represent the item/loot being picked up by the player.
 */
public class Loot
{
    //Stores the sprite of the loot.
    public Sprite sprite;
    //Loot type: So far can be Apple or Berry.
    public Item.ItemType lootType;
    //Amount picked up.
    public int lootAmount;

    //A function that returns the sprite of the loot.
    public Sprite getSprite() {
        return sprite;
    }

    //A function to check if the item is stackable.
    public bool isStackable() {
        switch (lootType) {
            default:
                return false;
            case Item.ItemType.Apple:
            case Item.ItemType.Berry:
                return true;
        }
    }
}
