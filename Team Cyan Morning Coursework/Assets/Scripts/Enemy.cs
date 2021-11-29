using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    //Logic
    public Transform[] waypoints;
    public bool random;
    public float checkRadius;

    private bool collidingWithPlayer;
    private Transform target;
    private Vector3 startingPosition;
    private int waypointIndex;
    private float dist;
    private int rand;
    private Animator animator;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        waypointIndex = 0;
        target = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {  
        if (Vector3.Distance(target.position, transform.position) < checkRadius)
        {
          if(Vector3.Distance(target.position, transform.position) < 0.3 && gameObject.name =="Witch")
            {
                animator.SetBool("Attack", true);
            }
            else if (gameObject.name =="Witch")
            {
                animator.SetBool("Attack", false);
            }
            if (!collidingWithPlayer)
            {
                
                moveDelta = Vector3.Normalize(target.position - transform.position);
                UpdateMotor(moveDelta * speed * Time.deltaTime);
            }
        }
        else
        {
            if (waypoints.Length != 0)
            {
                dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
                if (dist <= 0.1f)
                {
                    IncreaseIndex();
                }
                Patrol();
            }
           
        }

            //Check for overlaps
           	collidingWithPlayer = false;
           	boxCollider.OverlapCollider(filter, hits);
            for (int i = 0; i < hits.Length; i++)
           	{
            if(hits[i] == null)
                    continue;

            	if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            	{
            		collidingWithPlayer = true;
           	    }

           	//The array is not cleaned up, so we do it ourself
            	hits[i] = null;
            }
        }

    void Patrol()
    {
        moveDelta = Vector3.Normalize(waypoints[waypointIndex].position - transform.position);
        UpdateMotor(moveDelta * speed * Time.deltaTime);
    }
    void IncreaseIndex()
    {
        if (random)
        {
            rand = Random.Range(0, waypoints.Length);
            if (rand == waypointIndex)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = rand;
            }
        }
        else
        {
            waypointIndex++;
        }

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

    }

    protected override void Death()
        {
            //destroys enemy and its parent class to remove all unneeded gameobjects
        	Destroy(gameObject.transform.parent.gameObject);
        }
}