using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_onCollision : Collidable
{
    [SerializeField] private DialogueList transDialogue;

    protected override void OnCollide(Collider2D boxCollider)
    {
        if (boxCollider.name == "Player")
        {
            //Disables the player mover script until the transition screen is over.
            GameObject.Find("Player").GetComponent<Mover>().enabled = false;
            //Display the transition screen.
            GameObject.Find("Canvas").GetComponent<TransitionUI>().ShowTransition(transDialogue, 0);
            //Deletes the object that colides with the player, so the transition screen cannot be triggered again.
            Destroy(GameObject.Find("Transition 1"));
        }
    }
}
