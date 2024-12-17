using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float speed; //plat. vel.
    [SerializeField] int startingPoints; //num. to determinate the index of the init. point.
    [SerializeField] Transform[] points; //Array of the position points that will follow the platform.
    int i; //Index that determines wich number of platform its followed.

    // Start is called before the first frame update
    void Start()
    {
        //Set the initial position of platform in one of the points.
        transform.position = points[startingPoints].position;
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }

    void PlatformMove()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //index +1 to change the objective
            if (i == points.Length) i = 0;
        }

        //Plat. Movement. ALWAYS AFTER DETECTION!!!
        //Moves the platform to the array's point that matches to i's value.
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
