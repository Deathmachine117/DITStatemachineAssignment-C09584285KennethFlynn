//C09584285 Kenneth Flynn
using UnityEngine;
using System.Collections;
//This is the enemy class 
public class Enemy : MonoBehaviour 
{
	//This sets the navmesh agent for the enemy
	NavMeshAgent myNMA;
	//This sets the transform variable to track down the player
	Transform player;
	//This sets up the waypoint index
	public int waypointIndex = 0;
	//This is the array variable for the list that will be used to hold the waypoints
	public Transform[] waypoints;
	//This is the start function which will get the nav mesh component at runtime
	void Start () 
	{
		myNMA = transform.GetComponent<NavMeshAgent> ();

		//This sets up the enemy to track the player
	//	player = GameObject.FindWithTag ("Player").transform;
	}
	//This is the update function
	void Update ()
	{
		//This sets up the nav meshes destination as the position of the waypoints in the array
		myNMA.destination = waypoints[waypointIndex].position;
		//This if statement means if the remaining distance of the nav mesh is less than the stopping distance to do the following
		if (myNMA.remainingDistance < myNMA.stoppingDistance) 
		{
			//This is the debug message for when the enemy arrives at the destination
			Debug.Log("Enemy Here");
			//This picks a random waypoint from the array for the enemy to go to next
			waypointIndex = Random.Range(0,4);
		}
	}
}
