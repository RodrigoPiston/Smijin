using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    // -- Se declaran los waypoints
    [SerializeField] Transform[] wayPoints;

    public Transform[] GetWayPoints()
    {
        return wayPoints;
    }
}
