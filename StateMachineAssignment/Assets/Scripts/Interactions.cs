//c09584285 Kenneth Flynn
//This is the interactions script
using UnityEngine;
using System.Collections;
//This is the class for the interactions script
public class Interactions : MonoBehaviour {
	//These are the booleans which will be checked on when the player collects the keys
	public bool hasBlueKey;
	public bool hasRedKey;
	
	// This is the update function which will run the interact function at every frame
	void Update () 
	{
		Interact();
	}
	//This is the interact function for the player to see what happens when the key is collected
	void Interact()
	{
		//This is the if statement saying if the space key is pressed
		if(Input.GetKeyDown (KeyCode.Space))
		{
			//This is the raycast variable 
			RaycastHit hit;
			//This is the if statement which assigns the position, direction, and length of the raycast
			if(Physics.Raycast(transform.position, transform.forward , out hit, 50f))
			{
				//This is the debugs to see if the ray is working right and print a message to the console
				Debug.Log("Ray");
				//This is the debug to show the ray in the scene when space is pressed 
				Debug.DrawRay(transform.position, transform.forward, Color.white);
				//This is the if statement which controls the collision and contact with anything tagged as a keycard
				if(hit.collider.GetComponent<Keycards>() != null)
				{
					//This is the if statement which sets the blue and red booleans to true if the ray collides against the objects, it then destroys the object.
					if(hit.collider.GetComponent<Keycards>().whatColourAmI == Keycards.KeyColours.blueKey)
					{
						hasBlueKey = true;
						Destroy(hit.collider.gameObject);
					}
					if(hit.collider.GetComponent<Keycards>().whatColourAmI == Keycards.KeyColours.redKey)
					{
						hasRedKey = true;
						Destroy(hit.collider.gameObject);
					}
				}
				//This is the if statement which says if the ray collides against and object called doorred and the has red key boolean is true, that it will then destroy the object.
				if(hit.collider.name == "DoorRed")
				{
					if(hasRedKey)
					{
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}
	}
}