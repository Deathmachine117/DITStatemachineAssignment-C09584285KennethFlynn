//Kenneth Flynn C09584285
using UnityEngine;
using System.Collections;
//This is the class for the keycards in the game.
public class Keycards : MonoBehaviour {
	//This is the list of key colors in the game.
	public enum KeyColours
	{ 
		none,
		redKey, 
		blueKey 
	};
	//This is the variable to be used in the interactions script
	public KeyColours whatColourAmI;
}