//Kenneth Flynn C09584285
using UnityEngine;
using System.Collections;
//This is the class for the mouse movements
public class MouseMovement : MonoBehaviour 
{
	//This is the update function
	void Update ()
	{
		//This sets up the vector to take the mouses positions
		Vector3 v3 = Input.mousePosition;
		//This sets up the speed of the movement
		v3.z = 10.0f;
		//This takes the cameras view 
		v3 = Camera.main.ScreenToWorldPoint(v3);
		//This moves the object with a rigidbody to the position
		this.gameObject.rigidbody.MovePosition(v3);
		
	}
}
