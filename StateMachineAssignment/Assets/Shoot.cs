using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	GameObject bullet; //empty container for our bullet gameobject

	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Keypad8))
		{
			FireBulletUp(); //call the firebullet function
		}

		if(Input.GetKeyDown (KeyCode.Keypad4))
		{
			FireBulletLeft(); 
		}
		if(Input.GetKeyDown (KeyCode.Keypad6))
		{
			FireBulletRight(); 
		}

		if(bullet) //if there is a bullet
			Physics.IgnoreCollision(bullet.collider, collider); //tell two colliders to ignore each other
	}
	
	void FireBulletUp()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>(); //add rigidbody component
		bullet.rigidbody.useGravity = false; //turn of gravity on the rigidbody
		bullet.rigidbody.AddForce(transform.forward * 600f); //add force to the bullet
	}

	void FireBulletLeft()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>(); //add rigidbody component
		bullet.rigidbody.useGravity = false; //turn of gravity on the rigidbody
		bullet.rigidbody.AddForce(transform.right * -600f); //add force to the bullet
	}
	void FireBulletRight()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Rigidbody>(); //add rigidbody component
		bullet.rigidbody.useGravity = false; //turn of gravity on the rigidbody
		bullet.rigidbody.AddForce(transform.right * 600f); //add force to the bullet
	}
}