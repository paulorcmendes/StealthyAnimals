using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private GameObject player;
    private GameObject[] graph;
    [Range(0,1)]
    public float heuristicImportance;
    void Start()
    {
        graph = GameObject.FindGameObjectsWithTag("StealthWaypoint");
    }

    // Update is called once per frame
    void Update()
    {
        //mouse
        //Vector3 objective = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player = GameObject.FindGameObjectWithTag("Player");



        Vector3 objective = GetNextWaypoint();
        Vector3 vecDiff = objective - transform.position;
        
        if(vecDiff.magnitude > 0.5f)
        {
            Vector2 movVector = vecDiff.normalized * speed * Time.deltaTime;
            
            transform.Translate(movVector);
        } 
    }

    private Vector3 GetNextWaypoint()
    {
        GameObject currentWaypoint, goalWaypoint;

        currentWaypoint = graph[0];
        goalWaypoint = graph[0];

        for (int i = 0; i < graph.Length; i++)
        {
            if(Vector3.Distance(transform.position, graph[i].transform.position) < Vector3.Distance(transform.position, currentWaypoint.transform.position))
            {
                currentWaypoint = graph[i];
            }
            if (Vector3.Distance(player.transform.position, graph[i].transform.position) < Vector3.Distance(player.transform.position, goalWaypoint.transform.position))
            {
                goalWaypoint = graph[i];
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
            var min = open.OrderBy(kvp => kvp.Value).First();
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
        Stack<GameObject> path = new Stack<GameObject>();
        while (cur != null)
        {
            path.Push(cur);
            cur = father[cur];            
        }
        GameObject nextWaypoint;
        if(path.Count>1)
        {
            path.Pop();            
        }
        nextWaypoint = path.Pop();
        Debug.Log(nextWaypoint.name);
        return nextWaypoint.transform.position;
    }
    private float Rating(GameObject node)
    {
        return Vector3.Distance(node.transform.position, transform.position)*(1-heuristicImportance) + Vector3.Distance(node.transform.position, player.transform.position)*heuristicImportance;
    }
    private float DistGameObj(GameObject g1, GameObject g2)
    {
        return Vector3.Distance(g1.transform.position, g2.transform.position);
    }
}
