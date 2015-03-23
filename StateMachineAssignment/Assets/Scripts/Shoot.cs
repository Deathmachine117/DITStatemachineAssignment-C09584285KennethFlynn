//C09584285 Kenneth Flynn
using UnityEngine;
using System.Collections;
//This is the shooting class
public class Shoot : MonoBehaviour 
{
	//Creates a containing object for the bullet
	GameObject bullet;
	//This is the update function
	void Update () 
	{
		//These if statements are for if the keypad buttons are pressed then to fire their repective bullet functions
		if(Input.GetKeyDown (KeyCode.Keypad8))
		{
			FireBulletUp(); 
		}

		if(Input.GetKeyDown (KeyCode.Keypad4))
		{
			FireBulletLeft(); 
		}
		if(Input.GetKeyDown (KeyCode.Keypad6))
		{
			FireBulletRight(); 
		}
		//These tell the bullet to ignore the ships collider
		if(bullet) 
			Physics.IgnoreCollision(bullet.collider, collider); 
	}
	//This is the function used for creation, position and attributes of the bullet
	void FireBulletUp()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>(); 
		bullet.rigidbody.useGravity = false; 
		bullet.rigidbody.AddForce(transform.forward * 600f);
	}

	void FireBulletLeft()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>(); 
		bullet.rigidbody.useGravity = false; 
		bullet.rigidbody.AddForce(transform.right * -600f); 
	}
	void FireBulletRight()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>();
		bullet.rigidbody.useGravity = false; 
		bullet.rigidbody.AddForce(transform.right * 600f); 
	}
}