using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint:MonoBehaviour
{
    public enum WaypointType { Stealh, Brave};

    public WaypointType waypointType;

    public GameObject[] neighbors;
}
