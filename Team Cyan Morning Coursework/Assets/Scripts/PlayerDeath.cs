using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject playerGhost; //Player Ghost object/prefab.
    private Vector3 position; //Position at the time of death.
    private Quaternion rotation; //Rotation at the time of death.
    private GameObject[] listOfPlayerGhosts; //Array of PlayerGhost objects.

    private Coroutine collidersDisabled = null; //Coroutine for disabling the colliders for 1 second.


    [SerializeField] private DialogueList deathDialogue;

    //Function to set the death position and rotation of the player character.
    public void SetDeathPosition(Vector3 position, Quaternion rotation) {
        this.position = position;
        this.rotation = rotation;
    }

    //A function that respawns the player at the initial spawn point.
    public void respawnPlayer() {
        //When respawning the player, disable the colliders of the player so that they will not interact with the playerghost temporarily. This effect only lasts for 1 second.
        collidersDisabled = StartCoroutine(DisableColliderForSeconds(1));

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

        //Disable the mover.cs script of the player, so the player cannot move.
        gameObject.GetComponent<Mover>().enabled = false;
        //If the player has a weapon, the weapon script attached to the weapon is temporarily disabled too.
        if (transform.GetChild(1).gameObject != null) {
            transform.GetChild(1).gameObject.GetComponent<Weapon>().enabled = false;
        }

        // Show death screen, and re-enable the mover.cs script afterwards.
        GameObject.Find("RespawnPoint").GetComponent<Transition_onEvent>().DeathTransition(deathDialogue);
    }

    //A function that spawns a player ghost at the death location.
    public void SpawnGhost(Vector3 position, Quaternion rotation) {
        //Finds any object with the tag "PlayerGhost" and stores them in a GameObject array.
        listOfPlayerGhosts = GameObject.FindGameObjectsWithTag("PlayerGhost");
        //Loop through the array and destroy all PlayerGhost objects.
        for (int i = 0; i < listOfPlayerGhosts.Length; i++) {
            Destroy(listOfPlayerGhosts[i]);
        }

        //Now that all other Player Ghost objects is destroyed, set the death position and rotation, and spawn the player ghost object.
        SetDeathPosition(position, rotation);
        if (playerGhost != null)
        {
            Instantiate(playerGhost, this.position, this.rotation);
        }
        
    }

    //A function that disables the player's colliders for 1 second as soon as they die.
    //This is so they do not pick up the player ghost immediately before respawning at the respawn point.
    private IEnumerator DisableColliderForSeconds(float seconds)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
