using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointFollower : MonoBehaviour
{
    public float speed = 1;
    private int nextWaypointIndex = 0;
    [SerializeField] private float reachedWaypointClearance = 0.1f;

    private Transform[] waypoints;

    private void Start()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
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

        if (nextWaypointIndex == 16)
        {
            SceneManager.LoadScene("EndScreen");
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        transform.right = waypoints[nextWaypointIndex].position - transform.position;
    }
}
