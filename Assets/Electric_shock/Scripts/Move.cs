using System.Collections;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float delay = 4f;

    void Start()
    {
        Invoke("StartMovement", delay);
    }

    void StartMovement()
    {
        StartCoroutine(MoveToWaypoints());
    }

    IEnumerator MoveToWaypoints()
    {
        while (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;

            // Calculate direction to the waypoint
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0f; // Ensure no rotation in the y-axis

            // Rotate towards the waypoint
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360f * Time.deltaTime);
            }

            // Move towards the waypoint
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the player has reached the waypoint
            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }

            yield return null;
        }
    }
}
