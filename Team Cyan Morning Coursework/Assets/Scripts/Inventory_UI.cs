using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotGroup;
    private Transform itemSlot;

    private void Awake() {
        itemSlotGroup = transform.Find("Inventory_Slots");
        itemSlot = itemSlotGroup.Find("Inventory_Slot_1");
    }

    public void setInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshItemsInInventory();
    }

    private void RefreshItemsInInventory() {
        float x = 0.9f;
        float y = -1.01f;
        float cellSize = 20f;
        foreach (Loot item in inventory.getListOfItems())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotGroup).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
            x++;
            if (x > 3) {
                x = 0;
                y++;
            }
        }
    }
}
