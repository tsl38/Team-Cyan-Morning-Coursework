using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class can be placed on objects other than the player. It will detect what game object is colliding with it and store
 * it in to an array. This happens every Update() call.
 */
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter2D;
    private new BoxCollider2D collider; //Needs the boxcollider component to detect collisions.
    private Collider2D[] arrayOfHits = new Collider2D[50]; //An array to store a list of colliders that collided with this object.

    protected virtual void Start() {
        collider = GetComponent<BoxCollider2D>(); //Gets the boxcollider from this game object.
    }

    protected virtual void Update() {
        collider.OverlapCollider(filter2D, arrayOfHits); //Checks which object collided with this game object and store that collider in to arrayOfHits.

        //Loops through the arrayOfHits and check if each element is null, do nothing. 
        for (int i = 0; i < arrayOfHits.Length; i++) {
            if (arrayOfHits[i] == null) {
                continue;
            }

            OnCollide(arrayOfHits[i]);

            //Clean up the arrayOfHits so that this can repeat in he next Update call.
            arrayOfHits[i] = null;
        }
    }

    //Call this function to do something when collision occurs.
    protected virtual void OnCollide(Collider2D boxCollider) {
        Debug.Log(boxCollider.name);
    }
}
