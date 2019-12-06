using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public float GuardSpeed;
    public float ChaseSpeed;
    private float speed;
    private GameObject player;
    private GameObject[] graph;
    public float RotationSpeed;
    public float SeenDistance;

    private Light my_light;
    void Start()
    {
        graph = GameObject.FindGameObjectsWithTag("StealthWaypoint");
        my_light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse
        //Vector3 objective = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 objective;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, GetComponent<CircleCollider2D>().radius+0.01f, player.transform.position - transform.position);
             

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") && hit.distance < SeenDistance)
        {
            //Debug.Log(hit.collider.gameObject.name);
            speed = ChaseSpeed;
            my_light.color = Color.red;
            my_light.intensity = 10;
            objective = player.transform.position;
        }
        else
        {
            my_light.color = Color.white;
            my_light.intensity = 1;
            speed = GuardSpeed;
            objective = GetNextWaypoint();
        }
                
        Vector3 vecDiff = objective - transform.position;
        
        
        Vector2 movVector = vecDiff.normalized * speed * Time.deltaTime;


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, movVector)), Time.time*RotationSpeed); 
        transform.Translate(movVector, Space.World);
        
    }

    private Vector3 GetNextWaypoint()
    {
        GameObject currentWaypoint, goalWaypoint;

        currentWaypoint = graph[0];
        goalWaypoint = null;

        for (int i = 0; i < graph.Length; i++)
        {           
            if (DistGameObj(gameObject, graph[i])< DistGameObj(gameObject, currentWaypoint))
            {
                currentWaypoint = graph[i];
            }

            RaycastHit2D hit = Physics2D.Raycast(graph[i].transform.position, player.transform.position - graph[i].transform.position);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                if (goalWaypoint == null || DistGameObj(player, graph[i]) < DistGameObj(player, goalWaypoint))
                {
                    goalWaypoint = graph[i];
                }
            }
        }
        
        return AStarPartial(currentWaypoint, goalWaypoint);
    }

    private Vector3 AStarPartial(GameObject start, GameObject goal)
    {
        HashSet<GameObject> closed = new HashSet<GameObject>();

        Dictionary<GameObject, float> open = new Dictionary<GameObject, float>();
        Dictionary<GameObject, GameObject> father = new Dictionary<GameObject, GameObject>();

        foreach(GameObject waypoint in graph)
        {
            father.Add(waypoint, null);
        }

        open.Add(start, 0);

        while (true)
        {
            var min = open.OrderBy(kvp => kvp.Value+DistGameObj(player, kvp.Key)).First();
            GameObject current = min.Key;
            float value = min.Value;

            open.Remove(current);
            closed.Add(current);

            if (current.Equals(goal))
            {
                break;
            }

            foreach (GameObject n in current.GetComponent<Waypoint>().neighbors)
            {
                if (!closed.Contains(n))
                {
                    float dist = value + DistGameObj(current, n);
                    if (open.ContainsKey(n))
                    {
                        if(dist < open[n])
                        {
                            open[n] = dist;
                            father[n] = current;
                        }
                    }
                    else
                    {
                        open.Add(n, dist);
                        father[n] = current;
                    }
                }
            }
        }
        GameObject cur = goal;
        //Stack<GameObject> path = new Stack<GameObject>();
        String path = "Path: ";
        while (cur != null)
        {
            //path.Push(cur);
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, GetComponent<CircleCollider2D>().radius*1.1f, cur.transform.position - transform.position);
            path += cur.name + " ";
            if (hit.collider == null || !hit.collider.gameObject.CompareTag("Box") || hit.distance > DistGameObj(gameObject, cur))
            {
                Debug.Log(path+" next: "+cur.name);
                return cur.transform.position;
            }

            cur = father[cur];
        }
        
        return start.transform.position;
    }
    private float DistGameObj(GameObject g1, GameObject g2)
    {
        return Vector2.Distance(g1.transform.position, g2.transform.position);
    }
}
