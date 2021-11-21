using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtonClick : MonoBehaviour
{
    //When the button on the item slot is pressed.
    public void onItemButtonClicked() {
        //Gets the game object transform.
        Transform gameObj = gameObject.transform;
        //Sets the value of the x and y position of the item slot based on the values stored in the hidden text.
        string xStr = gameObj.Find("x").GetComponent<TextMeshProUGUI>().text;
        string yStr = gameObj.Find("y").GetComponent<TextMeshProUGUI>().text;

        //sets the index of the inventory item in the inventory list to be -1 by default.
        int index = -1;
        float x = float.Parse(xStr); //converts string to float for x.
        float y = float.Parse(yStr); //converts string to float for y.
        //If y is -1.06f, meaning if item slot is in the first row.
        if (y == -1.06f)
        {
            //index is the value of x - 0.95.
            index = (int)(x - 0.95f);
        }
        //If item slot is on the second row.
        else if (y == -2.06f) 
        {
            //index is the value of x - 0.95 + 3.
            index = (int)((x - 0.95f) + 3f);
        }

        //Checks to make sure x is not -1, then remove item from the inventory.
        if (index >= 0) {
            Loot item = GameObject.Find("Player").GetComponent<Player>().playerInventory.removeItem(index);
            //Use item.
        }

        Debug.Log("Button Clicked: " + index);
    }
}
