//Kenneth Flynn C09584285
using UnityEngine;
using System.Collections;
//This is the reset class for the game
public class Reset : MonoBehaviour 
{
	//This is the if statement which will run at every frame
	void Update ()
	{
		//This if statement says that if the r button is pressed that it will then load level 1
		if(Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel("Level1");
		}
	}
}
