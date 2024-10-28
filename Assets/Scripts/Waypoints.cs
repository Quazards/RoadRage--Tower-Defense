using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoint;

    private void Awake()
    {
        waypoint = new Transform[transform.childCount];
        for (int i = 0; i < waypoint.Length; i++)
        {
            waypoint[i]= transform.GetChild(i);
        }
    }
}
