using UnityEngine;

// script made to store a damage interaction between the enemy and the player 
public struct Damage
{
    public Vector3 origin; //original position of the attacked game object
    public int damageAmount; //amount of damage given by the attack
    public float pushForce; // how much force the attacked player will be pushed back by
}
