using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum WaypointType { Stealh, Brave };

    public WaypointType waypointType;

    public GameObject[] neighbors;
    public float maxDist;
    public GameObject guard;

    void Start()
    {
        List<GameObject> waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("StealthWaypoint"));
        List<GameObject> neighborsList = new List<GameObject>();

        foreach(GameObject w in waypoints)
        {
            float wDist = Vector3.Distance(w.transform.position, gameObject.transform.position);
            if (w.Equals(gameObject) || wDist > maxDist)
            {
                continue;
            }
            else
            {
                RaycastHit2D hit = Physics2D.CircleCast(transform.position, guard.GetComponent<CircleCollider2D>().radius*1.5f, w.transform.position - transform.position);

                if (hit.collider != null && hit.collider.gameObject.CompareTag("Box") && hit.distance < wDist)
                {
                    continue;
                }
                else
                {
                    neighborsList.Add(w);
                    Debug.DrawLine(transform.position, w.transform.position, Color.red, float.MaxValue);
                }
            }
        }

        neighbors = neighborsList.ToArray();
    }
}