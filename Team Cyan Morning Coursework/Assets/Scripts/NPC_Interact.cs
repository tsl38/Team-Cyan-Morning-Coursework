using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : Collidable
{

    [SerializeField] private DialogueList npcDialogue;
    [SerializeField] private string maleFemaleOld;

    protected override void OnCollide(Collider2D boxCollider)
    {
        //Debug.Log(collision.collider.name);
        if ((boxCollider.name == "Player" || boxCollider.name == "Head Collider") && Input.GetKeyDown(KeyCode.F))
        {
            //Makes sure the game is not paused.
            if (PauseMenu.isGamePaused == false)
            {
                //Debug.Log("NPC is here");     // Testing purposes
                GameObject.Find("Canvas").GetComponent<DialogueUI>().ShowDialogue(npcDialogue, maleFemaleOld, gameObject.name);
            }
        }
    }
}
