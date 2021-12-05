using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtonClick : MonoBehaviour
{
    public KeyCode key; //The keyCode for keyboard keys.

    private Button button; //The button component attached to the gameObject.

    private void Awake() {
        //Initializes the button component.
        button = GetComponent<Button>();
    }

    private void Update() {
        //When the button with KeyCode key is pressed down, call the function that was set to in the onClick function.
        if (Input.GetKeyDown(key))
        {
            ChangeColorOnButtonPress(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(key)) 
        {
            ChangeColorOnButtonPress(button.colors.normalColor);
        }
    }

    private void ChangeColorOnButtonPress(Color color) {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    //When the button on the item slot is pressed.
    public void OnItemButtonClicked() {
        //Only Runs if the game is not paused.
        if(PauseMenu.isGamePaused == false && GameObject.Find("Canvas").GetComponent<TransitionUI>().GetTransitionUI().activeSelf == false) {
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
                Loot item = GameObject.Find("Player").GetComponent<Player>().playerInventory.RemoveItem(index);
                //Set the loot amount to be 1.
                item.lootAmount = 1;
                //Use item.
                bool successful = UseItem(item);
                //If not used successfully, add the item back in to the inventory.
                if (!successful)
                {
                    GameObject.Find("Player").GetComponent<Player>().playerInventory.AddItem(item);
                }
                else 
                {
                    //Plays the item consumption sound if item used successfully.
                    FindObjectOfType<SoundManager>().Play("ItemConsumption");
                }
            }

            Debug.Log("Button Clicked: " + index);
        }
    }

    //Function that uses the item removed from the inventory.
    private bool UseItem(Loot item) {
        //Bool value to indictate whether or not the item was used successfully.
        bool usedsuccessfully = false;
        //If the loot type is Apple or Berry, then heal the player.
        if (item.lootType == Item.ItemType.Apple || item.lootType == Item.ItemType.Berry)
        {
            int heal = item.GetHealingAmount(); //gets the heal amount based on the item type.
            //Only uses the item to heal the player if the player's current hp is less than the max hp.
            if (GameObject.Find("Player").GetComponent<Player>().hitpoint < GameObject.Find("Player").GetComponent<Player>().maxHitpoint) {
                GameObject.Find("Player").GetComponent<Player>().hitpoint += heal;
                //if the resulting hp is larger than the max hp, set the hp to be the max hp.
                if (GameObject.Find("Player").GetComponent<Player>().hitpoint > GameObject.Find("Player").GetComponent<Player>().maxHitpoint)
                {
                    GameObject.Find("Player").GetComponent<Player>().hitpoint = GameObject.Find("Player").GetComponent<Player>().maxHitpoint;
                }
                //Finds the Health_Bar_UI object in the UI canvas, and then finds the script attached to it to get the health list, and add the updated values to the list.
                GameObject.Find("Health_Bar_UI").GetComponent<Health_Bar_UI>().GetList().ChangeHealth(GameObject.Find("Player").GetComponent<Player>().hitpoint, GameObject.Find("Player").GetComponent<Player>().maxHitpoint);
                usedsuccessfully = true;
            }
        }

        return usedsuccessfully;
    }
}
