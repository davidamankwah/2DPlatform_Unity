using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavepointfollow : MonoBehaviour
{
 [SerializeField] private GameObject[] wavepoints; //reference to wavepoint game objects
 private int currentWaypointIndex = 0; //keeps track of current wavepoints
 [SerializeField] private float speed = 2f; //speed of platform
    // Update is called once per frame
    void Update()
    {
       //check the distance between the platform and the currently active wavepoint
       //To know if its is close, so it can switch the next wavepoint
       //Vector2.Distance() calculates distances between two vectors
       //if the platform and current wavepoint is less than .1f, switch to next wavepoint.
       if (Vector2.Distance(wavepoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++; //increment currentWaypointIndex

            //checks if currentWaypointIndex greater than wave point length
            if (currentWaypointIndex >= wavepoints.Length)
            {
                currentWaypointIndex = 0; // Reset currentWaypointIndex to 0
            }
        }

        //set platform position new position
        //Vector2.MoveTowards() calculates new position
        //
        transform.position = Vector2.MoveTowards(transform.position, wavepoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);   
    }
}
