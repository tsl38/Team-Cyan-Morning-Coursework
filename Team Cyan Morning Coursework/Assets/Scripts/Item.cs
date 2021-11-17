using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collectable
{
    public enum ItemType { 
        Apple,
        Berry,
    }
    public ItemType itemType;
    public int amount;


    protected override void OnCollect() {
        if (!collected)
        {
            base.OnCollect();
            Debug.Log("Grabbed an apple!");
            Destroy(this.gameObject);
        }
    }
}
