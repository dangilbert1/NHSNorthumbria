using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using UnityEngine.AI;

public class WaypointIndexTriggerActivate : MonoBehaviour
{
    public navMove navmove;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WayPointIndex()
    {
        Debug.Log(navmove.currentPoint);

        int pointNumber = navmove.currentPoint;
        Transform thisPoint = navmove.waypoints[pointNumber];

        GameObject childTrigger = thisPoint.GetChild(0).gameObject;
        childTrigger.SetActive(enabled);

    }

  
}
