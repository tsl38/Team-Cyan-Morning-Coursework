using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : Collectable
{
    protected override void OnCollect()
    {
        //If the ghost has not been collected.
        if (!collected) {
            //Set the ghost as collected.
            base.OnCollect();
            //Restore the player's max hp back to 10.
            GameObject.Find("Player").GetComponent<Player>().maxHitpoint = 10;
            //Heal the player back to 10 hp.
            GameObject.Find("Player").GetComponent<Player>().hitpoint = GameObject.Find("Player").GetComponent<Player>().maxHitpoint;
            //Update the healthing list of the player to trigger an update with the health bar UI.
            GameObject.Find("Health_Bar_UI").GetComponent<Health_Bar_UI>().GetList().ChangeHealth(GameObject.Find("Player").GetComponent<Player>().hitpoint, GameObject.Find("Player").GetComponent<Player>().maxHitpoint);
            //Destroy the current game object.
            Destroy(gameObject);
            Debug.Log("Collected Ghost!");
        }
    }
}
