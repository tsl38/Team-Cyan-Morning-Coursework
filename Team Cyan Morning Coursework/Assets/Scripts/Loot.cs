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
    //Loot ID.
    public int id;

    //Item effect.
    private int healingAmount;

    //A function that returns the sprite of the loot.
    public Sprite GetSprite() {
        return sprite;
    }

    //A function to check if the item is stackable.
    public bool IsStackable() {
        switch (lootType) {
            default:
                return false;
            case Item.ItemType.Apple:
            case Item.ItemType.Berry:
                return true;
        }
    }

    public int GetHealingAmount() {
        switch (lootType)
        {
            default:
                healingAmount = 0;
                return healingAmount;
            case Item.ItemType.Apple:
                healingAmount = 1;
                return healingAmount;
            case Item.ItemType.Berry:
                healingAmount = 2;
                return healingAmount;
        }
    }

    //Temp function. Might need. If not needed, can delete.
    //Temp function. Might need. If not needed, can delete.
    //Temp function. Might need. If not needed, can delete.
    public int GetItemID()
    {
        switch (lootType)
        {
            default:
                id = 0;
                return id;
            case Item.ItemType.Apple:
                id = 10;
                return id;
            case Item.ItemType.Berry:
                id = 20;
                return id;
        }
    }
}
