using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;

    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            nextWaypointIndex++;

            Vector3 targetPos = waypoints[nextWaypointIndex].transform.position;
            Vector3 targetPosFlattened = new Vector3(targetPos.x, targetPos.y - 90, 0);
            transform.LookAt(targetPosFlattened);
            //transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(Y,X));
        }
        if (nextWaypointIndex >= waypoints.Length)
        {
            nextWaypointIndex = 0;
        }
    }
}