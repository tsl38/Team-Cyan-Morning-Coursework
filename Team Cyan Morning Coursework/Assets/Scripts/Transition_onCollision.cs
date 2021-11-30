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
            GameObject.Find("Canvas").GetComponent<TransitionUI>().ShowTransition(transDialogue, 0);
            Destroy(GameObject.Find("Transition 1"));
        }
    }
}
