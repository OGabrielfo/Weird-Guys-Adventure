using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerSkull : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    public float waitTime;

    private int currentWaypoint = 0;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        
    }

    public void MoveToNextWaypoint(float speed)
    {
        if (waypoints.Length == 0) return;

        var currentTarget = waypoints[currentWaypoint].position;
        var moveDirection = currentTarget - transform.position;
        var moveAmount = speed * Time.deltaTime;

        if (moveDirection.magnitude <= moveAmount)
        {
            // Reached the current waypoint
            if (currentWaypoint == waypoints.Length - 1)
            {
                // Reached the final waypoint, start over
                currentWaypoint = 0;
            }
            else
            {
                // Move to the next waypoint
                currentWaypoint++;
            }

            // Update the animation

            animator.SetBool("Idle", true);
        }
        else
        {
            // Move towards the current waypoint
            transform.position += moveDirection.normalized * moveAmount;
        }



        Vector3 velocity = moveDirection.normalized * speed;

        //Flip
        if (velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
