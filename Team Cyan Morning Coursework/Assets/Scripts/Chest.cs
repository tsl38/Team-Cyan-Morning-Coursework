using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public int goldAmount = 10;
    public Sprite emptyChestSprite;

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GameObject.Find("Player").GetComponent<Gold_Amount>().addGold(goldAmount);
            GetComponent<SpriteRenderer>().sprite = emptyChestSprite;
        }
    }
}
