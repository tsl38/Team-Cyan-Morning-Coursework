using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : Collidable
{

    [SerializeField] private DialogueList npcDialogue;

    // Start is called before the first frame update
    protected override void OnCollide(Collider2D boxCollider)
    {
        //Debug.Log(collision.collider.name);
        if ((boxCollider.name == "Player" || boxCollider.name == "Head Collider") && Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("NPC is here");     // Testing purposes
            GameObject.Find("Canvas").GetComponent<DialogueUI>().ShowDialogue(npcDialogue);
        }
    }
}
