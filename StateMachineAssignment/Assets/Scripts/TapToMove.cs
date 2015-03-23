//Kenneth Flynn C09584285
using UnityEngine;
using System.Collections;
//This script was taken from Unity answers as I wouldnt have been able to do this
//This is the class to get the ship to follow after the mouse click
public class TapToMove : MonoBehaviour
{
	//This boolean is set to true on click
	private bool flag = false;
	//This is the vector of where the player ends up
	private Vector3 endPoint;
	//This is the movement speed float
	public float duration = 50.0f;
	//Vertical position float
	private float yAxis;
	//The start function of the object
	void Start()
	{
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
	}
	
	//Update function
	void Update () {
		
		//This if statement checks to see if the screen is touched or the mouse is clicked
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
		{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray;
			//for unity editor
			#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif
			
			//If statement checks if it hits colliders
			if(Physics.Raycast(ray,out hit))
			{
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the click / tap position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on touch position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log(endPoint);
			}
			
		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
		{ 
			//This moves the gameobject to the position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) 
		{
			flag = false;
			Debug.Log("I am here");
		}
	}
}