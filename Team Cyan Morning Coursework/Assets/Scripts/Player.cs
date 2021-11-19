using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed; 
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Vector3 lastDirection;

    public Inventory playerInventory; //Inventory object.

    private void Awake() {
        //Initializes the player inventory.
        playerInventory = new Inventory();
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        lastDirection = Vector3.one * speed / 10;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed/10;
        float y = Input.GetAxisRaw("Vertical")* speed/10;

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction depending on player movement
        if (moveDelta.x != lastDirection.x && moveDelta.x != 0)
        {
            Vector3 t = transform.localScale;
            t.x *= -1;
            transform.localScale = t;
            lastDirection = moveDelta;
        }

        // Ensure character is allowed to move in y direction by casting a box there, if it returns null, character can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make sprite move in y-axis
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Ensure character is allowed to move in x direction by casting a box there, if it returns null, character can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make sprite move in x-axis
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
