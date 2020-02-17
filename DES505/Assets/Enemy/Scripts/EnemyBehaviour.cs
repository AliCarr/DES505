using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Range(0.1f, 3.0f)]
    public float speed;
    private Transform[] waypoints;
    private int waypointIndex = 0;

    public void SetWaypoints(Transform[] newWayPoints)
    {
        waypoints = newWayPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].position)
                waypointIndex++;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
