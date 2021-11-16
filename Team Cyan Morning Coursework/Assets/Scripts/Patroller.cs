using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    public bool random;
    
    private int waypointIndex;
    private float dist;
    private int rand;
    private Vector3 moveDelta;
    private float turn;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
     
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
      if(dist <= 0.1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        moveDelta = Vector3.Normalize(waypoints[waypointIndex].position - transform.position);
        transform.Translate( moveDelta * speed * Time.deltaTime);
    }
    void IncreaseIndex()
    {
        if (random)
        {
            rand = Random.Range(0, waypoints.Length);
            if(rand == waypointIndex)
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
       
        if(waypointIndex>= waypoints.Length)
        {
            waypointIndex = 0;
        }
        // check facing direction 
        turn = Mathf.Sign(Vector3.Normalize(waypoints[waypointIndex].position - transform.position).x);
        if (turn + Mathf.Sign(moveDelta.x)==0)
        {
            transform.localScale = new Vector3(turn, transform.localScale.y, 1);
        }
        
    }
}
