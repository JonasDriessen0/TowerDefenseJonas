using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public float speed = 1;
    private int nextWaypointIndex = 0;
    [SerializeField] private float reachedWaypointClearance = 0.25f;

    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position);

        if (distanceToWaypoint <= reachedWaypointClearance)
        {
            nextWaypointIndex++;
            if (nextWaypointIndex >= waypoints.Length)
            {
                nextWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        transform.right = waypoints[nextWaypointIndex].position - transform.position;
    }
}
