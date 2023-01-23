using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointfollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currectWayPointIndex = 0; 
    [SerializeField] private float speed = 4f;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currectWayPointIndex].transform.position,transform.position) < 0.1f){
            currectWayPointIndex++;
            if(currectWayPointIndex >= waypoints.Length){
                currectWayPointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currectWayPointIndex].transform.position, Time.deltaTime*speed);
    }
}
