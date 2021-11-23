using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory_UI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotGroup;
    private Transform itemSlot;

    private void Awake()
    {
        itemSlotGroup = transform.Find("Inventory_Slots");
        itemSlot = itemSlotGroup.Find("Inventory_Slot_1");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshItemsInInventory();

        //Subriscribe to the event in Inventory.
        this.inventory.OnItemListChange += Inventory_onItemListChange;
        RefreshItemsInInventory();
    }

    //On triggering the event in Inventory, calls the function RefreshItemsInInventory().
    private void Inventory_onItemListChange(object sender, System.EventArgs e)
    {
        RefreshItemsInInventory();
    }

    private void RefreshItemsInInventory()
    {
        if (itemSlotGroup != null)
        {
            //Destroy all item slots in the item slot group, except the item_slot_1 object, which acts as a template.
            foreach (Transform child in itemSlotGroup)
            {
                if (child == itemSlot)
                {
                    continue;
                }
                Destroy(child.gameObject);
            }

            float x = 0.95f; //Initial x posiiton
            float y = -1.06f; //Initial y position
            float cellSize = 19f; //size of the item slot.
            //Loops through all items in the inventory.
            foreach (Loot loot in inventory.GetListOfItems())
            {
                //Instantiate a new item slot under the item slot group and set it to be active (not hidden)
                RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotGroup).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                //Set the position of the item slot in the UI.
                itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);

                //Finds the icon image under the item slot.
                Image image = itemSlotRectTransform.Find("Icon").GetComponent<Image>();
                //Sets the image to the sprite of the item in the inventory.
                image.sprite = loot.GetSprite();

                //Finds the Amount text under the item slot.
                TextMeshProUGUI amountText = itemSlotRectTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                //If the loot amount is greater than 1, set the text to the amount.
                if (loot.lootAmount > 1)
                {
                    amountText.SetText(loot.lootAmount.ToString());
                }
                //If the amount is 1 or less, hide the text by setting it to nothing.
                else
                {
                    amountText.SetText("");
                }

                TextMeshProUGUI xText = itemSlotRectTransform.Find("x").GetComponent<TextMeshProUGUI>();
                xText.enabled = false;
                xText.SetText(x.ToString());
                TextMeshProUGUI yText = itemSlotRectTransform.Find("y").GetComponent<TextMeshProUGUI>();
                yText.enabled = false;
                yText.SetText(y.ToString());

                //Increments the x position
                x++;
                //If x is larger than 3
                if (x > 3f)
                {
                    //set x back to 0 and increment y.
                    x = 0.95f;
                    y--;
                }
            }
        }
    }
}
