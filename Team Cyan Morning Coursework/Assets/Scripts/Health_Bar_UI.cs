using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_UI : MonoBehaviour
{
    private PlayerHealthList healthList;
    private Transform Health_Heart_Group;
    private Transform Health_Heart;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Awake()
    {
        Health_Heart_Group = transform.Find("Health_Bar_Hearts");
        Health_Heart = Health_Heart_Group.Find("Heart_1");
    }

    public void SetHealthStats(PlayerHealthList healthList)
    {
        //The health list contains the current health value (list[0]) and max health value (list[1]).
        this.healthList = healthList;

        //Subriscribe to the event in UIButtonClick.cs.
        this.healthList.onHealthChange += healthBar_onHealthChange;
        RefreshHealthBarUI();
    }

    //On triggering the event in UIButtonClick.cs and , calls the function RefreshHealthBarUI().
    private void healthBar_onHealthChange(object sender, System.EventArgs e)
    {
        RefreshHealthBarUI();
    }

    public void RefreshHealthBarUI()
    {
        //Destroy all hearts in the health_heart_group, except the heart_1 object, which acts as a template.
        foreach (Transform child in Health_Heart_Group)
        {
            if (child == Health_Heart)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        float x = 1.15f; //Initial x posiiton
        float y = -0.97f; //Initial y position
        float cellSize = 35f; //size of the heart.

        RectTransform itemSlotRectTransform = null;
        //Loops through all items in the inventory.
        for (int i = 0; i < this.healthList.GetHealthList()[1] / 2; i++)
        {
            //Instantiate a new item slot under the item slot group and set it to be active (not hidden)
            itemSlotRectTransform = Instantiate(Health_Heart, Health_Heart_Group).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            //Set the position of the item slot in the UI.
            itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);

            //Finds the icon image under the item slot.
            Image image = itemSlotRectTransform.GetComponent<Image>();
            //Sets the image to the sprite of the item in the inventory.
            image.sprite = fullHeart;
            //Increments the x position

            //Calculates missing hp.
            int missingHealth = this.healthList.GetHealthList()[1] - this.healthList.GetHealthList()[0];
            //Only run the following if the current index i is at a point where full hearts are not allowed.
            if (i == this.healthList.GetHealthList()[0] / 2)
            {
                //If missingHealth is even.
                if (missingHealth % 2 == 0)
                {
                    //Start index of empty hearts.
                    int startIndex = this.healthList.GetHealthList()[0] / 2;
                    //Current heart position.
                    x = 1.15f + startIndex;
                    //Loops from current index till final health heart
                    for (int j = startIndex; j < this.healthList.GetHealthList()[1] / 2; j++)
                    {
                        //Instantiate a new item slot under the item slot group and set it to be active (not hidden)
                        itemSlotRectTransform = Instantiate(Health_Heart, Health_Heart_Group).GetComponent<RectTransform>();
                        itemSlotRectTransform.gameObject.SetActive(true);
                        //Set the position of the item slot in the UI.
                        itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
                        image = itemSlotRectTransform.GetComponent<Image>();
                        image.sprite = emptyHeart;
                        //Increments the position of the heart.
                        x++;
                        //Break the loop when number of hearts is half of the total max hp.
                        if (x > this.healthList.GetHealthList()[1] / 2 + 1)
                        {
                            break;
                        }
                    }
                }
                //If missing health is odd.
                else
                {
                    //Number of empty heart. Number of half hearts is 1.
                    int numberOfHeartsEmpty = (missingHealth - 1) / 2;
                    //Start index of empty heart.
                    int startIndex = this.healthList.GetHealthList()[1] / 2 - numberOfHeartsEmpty;
                    //Display half heart first, which is position -1 from the start of empty hearts.
                    x = 1.15f + startIndex - 1;
                    //Instantiate a new item slot under the item slot group and set it to be active (not hidden)
                    itemSlotRectTransform = Instantiate(Health_Heart, Health_Heart_Group).GetComponent<RectTransform>();
                    itemSlotRectTransform.gameObject.SetActive(true);
                    //Set the position of the item slot in the UI.
                    itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
                    image = itemSlotRectTransform.GetComponent<Image>();
                    image.sprite = halfHeart;
                    //Increments the position of the heart.
                    x++;
                    //Loops from current index till final health heart
                    for (int j = startIndex; j < this.healthList.GetHealthList()[1] / 2; j++)
                    {
                        //Instantiate a new item slot under the item slot group and set it to be active (not hidden)
                        itemSlotRectTransform = Instantiate(Health_Heart, Health_Heart_Group).GetComponent<RectTransform>();
                        itemSlotRectTransform.gameObject.SetActive(true);
                        //Set the position of the item slot in the UI.
                        itemSlotRectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
                        image = itemSlotRectTransform.GetComponent<Image>();
                        image.sprite = emptyHeart;
                        //Increments the position of the heart.
                        x++;
                        //Break the loop when number of hearts is half of the total max hp.
                        if (x > this.healthList.GetHealthList()[1] / 2 + 1)
                        {
                            break;
                        }
                    }
                }
                //Break the outer loop when number of hearts is half of the total max hp.
                if (x > this.healthList.GetHealthList()[1] / 2 + 1)
                {
                    break;
                }
            }
            x++;
        }
    }

    public PlayerHealthList GetList() {
        return healthList;
    }
}
