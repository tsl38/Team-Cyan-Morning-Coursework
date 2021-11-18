using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to represent any object that is collectable for the player. E.g. chests, items etc.
 */
public class Collectable : Collidable
{
    //Bool to indicate whether or not an object has been collected.
    protected bool collected;

    //Overrides the OnCollide function from Collidable class.
    protected override void OnCollide(Collider2D boxCollider)
    {
        //A collectable can only be collected by the player.
        if (boxCollider.name == "Player")
        {
            OnCollect();
        }
    }

    //A function to set the collected to be true.
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
