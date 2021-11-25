using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void respawnPlayer() {
        //Checks if the current max hp is more than 4, decrease the max hp by 2. Otherwise, do nothing.
        if (gameObject.GetComponent<Player>().maxHitpoint > 4) {
            gameObject.GetComponent<Player>().maxHitpoint = gameObject.GetComponent<Player>().maxHitpoint - 2; 
        }
        //Sets the current hp to the current max hp to fully heal the player.
        gameObject.GetComponent<Player>().hitpoint = gameObject.GetComponent<Player>().maxHitpoint;
        //Updates the health list for the player, so that the health_bar_UI will be updated.
        GameObject.Find("Health_Bar_UI").GetComponent<Health_Bar_UI>().GetList().ChangeHealth(gameObject.GetComponent<Player>().hitpoint, gameObject.GetComponent<Player>().maxHitpoint);

        //Respawns the player at the original position. Will respawn the player at 0, 0, 0 if the RespawnPoint object is not found.
        if (GameObject.Find("RespawnPoint") != null)
        {
            Vector3 respawnPoint = GameObject.Find("RespawnPoint").transform.position;
            gameObject.transform.position = respawnPoint;
        }
        else 
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Please create an object called \"RespawnPoint\" in the hierarchy. The player has respawned at 0, 0, 0 for now.");
        }
    }
}
