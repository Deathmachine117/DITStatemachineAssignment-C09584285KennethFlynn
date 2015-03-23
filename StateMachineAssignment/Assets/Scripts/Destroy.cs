//Kenneth Flynn C09584285
using UnityEngine;
using System.Collections;
//This is the destroy class
public class Destroy : MonoBehaviour 
{
	//This function means that if the sphere objects collide with the enemy it will be destroyed.
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name ==  "Sphere")
		{
			Destroy(gameObject);
		}
	}
}
