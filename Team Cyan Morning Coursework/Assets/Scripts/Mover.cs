using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    public int speed;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset moveDelta
        moveDelta = input;

        // Swap sprite direction depending on player movement
        if (moveDelta.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*Mathf.Sign(moveDelta.x), transform.localScale.y, transform.localScale.z);
        }

        // Add push Vector if any 
        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // Ensure character is allowed to move in y direction by casting a box there, if it returns null, character can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            // Make sprite move in y-axis
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Ensure character is allowed to move in x direction by casting a box there, if it returns null, character can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            // Make sprite move in x-axis
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
