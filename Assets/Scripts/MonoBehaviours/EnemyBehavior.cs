using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    private Waypoints waypoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < waypoints.waypoints.Length - 1)
            {
                waypointIndex++;
            } else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TreeTop")
        {
            Destroy(gameObject);
        }
    }

    public float DistanceToGoal()
    {
        float distance = 0;
        if (waypointIndex < waypoints.waypoints.Length - 1)
        {
            distance += Vector2.Distance(gameObject.transform.position, waypoints.waypoints[waypointIndex + 1].transform.position);
            for (int i = waypointIndex + 1; i < waypoints.waypoints.Length - 1; i++)
            {
                Vector3 startPosition = waypoints.waypoints[i].transform.position;
                Vector3 endPosition = waypoints.waypoints[i + 1].transform.position;
                distance += Vector2.Distance(startPosition, endPosition);
            }
        } else
        {
            distance += Vector2.Distance(gameObject.transform.position, waypoints.waypoints[waypointIndex].transform.position);
        }
        
        return distance;
    }
}
