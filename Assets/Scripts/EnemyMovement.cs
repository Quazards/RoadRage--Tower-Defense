using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 50f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoint[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNewWaypoint();
        }
    }

    private void GetNewWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoint.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoint[wavepointIndex];
    }

    private void EndPath()
    {
        PlayerManager.Lives--;
        Destroy(gameObject);
    }
}
