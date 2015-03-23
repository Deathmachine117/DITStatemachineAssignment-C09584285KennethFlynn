//C09584285 Kenneth Flynn
using UnityEngine;
using System.Collections;
//This is the class for the turret in the game.
public class Turret : MonoBehaviour {
	//These are the transform variables for the player and turret
	Transform turret,player;
	//These are the floats for the shooting
	float shootTime, shootTimer = 0.3f;
	//They are the floats for the random look timers
	float randLookTime, randLookTimer = 0.3f;
	//This is the ray variable
	Ray ray;
	//This is the variable for the hit of the raycast
	RaycastHit target;
	//This makes the game object bullets
	GameObject bullet;
	//These are the states that the turret will go through in its running
	enum States 
	{
		Initialize,
		Sleep,
		Attack,
	}
	//This sets the first state that the turret as the initilize state
	States currentState = States.Initialize; 
	//This is the update function for the enemy 
	void Update () 
	{
		//This is the switch to pass in the current state
		switch(currentState) 
		{
		//These are the cases which will run their functions when the case is called
		case States.Initialize:
			Initilize();
			break;
		case States.Sleep:
			Sleep ();
			break;
		case States.Attack:
			Attack ();
			break;
		}
		//This is the debug message to draw the ray of the turret in the scene view.
		Debug.DrawRay(turret.position, turret.transform.forward * 10f, Color.black);
	}
	//This is the function for the initilize case
	void Initilize()
	{
		//At runtime these two lines mean that the turret will find the gunpivot and the player tagged objects
		turret = GameObject.Find ("GunPivot").transform;
		player = GameObject.FindWithTag("Player").transform;
		//This then sets the state of the turret to sleep
		currentState = States.Sleep;
	}
	//This is the function for the sleep case
	void Sleep()
	{
		//This if statement means that if the raycast hits the player tagged objects that the state is then set to attack
		if(DoRayCast())
		{
			if(target.transform.tag == "Player")
			{
				currentState = States.Attack;
			}
		}
	}	
	//This is the function for the attack case
	void Attack()
	{
		//This creates a new vector that will look at the players position
		Vector3 lookAtPlayer = new Vector3( player.position.x, this.transform.position.y, player.position.z ); 
		//This causes the turret to look at the player
		turret.LookAt(lookAtPlayer); 
		//This sets up the shootime and counts upwards
		shootTime += Time.deltaTime;
		//This is if the shootime is greater or equal to the timer then it will shoot
		if(shootTime >= shootTimer)
		{
			shootTime = 0;
			//This calls the fire bullet function
			FireBullet();
			//This if statement means if the bullet is fired to avoid the collider of the turret.
			if(bullet) //if there is a bullet
				Physics.IgnoreCollision(bullet.collider, collider);

		}
		//This if statment means if the players position away from the turret is longer than fifteen that the current state is set to the sleep case
		if(Vector3.Distance(turret.position, player.position) > 15f)
		{
			currentState = States.Sleep;
		}
	}
	//This is the boolean for the raycast, it returns true if its hits the players collider.
	bool DoRayCast() //bool return type, returns true if ray hits a collider
	{
		//This is a new ray which is created at the turrets position and shoots forward
		ray = new Ray(this.transform.position, turret.transform.forward); 
		//This sends out the ray at the above position and and assigns the length
		bool rayHit = Physics.Raycast(ray, out target, 10f); 
		//This returns the ray on a collision true or false.
		return rayHit; 
	}
	//This is the fire bullet function that will be used when the turret fires
	void FireBullet()
	{
		//This creates the bullet and assigns it as a sphere primitive.
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//This sets up the scale on the x,y,z of the sphere
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		//This sets the color of the material to black
		bullet.renderer.material.color = Color.black;
		//This creates the bullet at the turret position.
		bullet.transform.position = this.transform.position;
		//This adds the rigidbody component to the bullet
		bullet.AddComponent<Rigidbody>(); 
		//This turns off rigidbody using any gravity
		bullet.rigidbody.useGravity = false; 
		//This adds force to the bullet when its fired
		bullet.rigidbody.AddForce(transform.up * -600f); 
	}
}	