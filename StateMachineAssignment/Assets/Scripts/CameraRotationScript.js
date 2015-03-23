//Kenneth Flynn C09584285
//This is the script used to rotate the camera in the game
//This is the target variable
var target :Transform ;
//This is the update function
function Update ()
{
	//This code basically that if q or e is pressed that the camera shall rotate at a 45 degree angle
    var rot : Vector3 = transform.rotation.eulerAngles;
    if(Input.GetKey(KeyCode.Q))
    {
        rot.y += 45 * Time.deltaTime;
    }
 	    if(Input.GetKey(KeyCode.E))
    {
        rot.y -= 45 * Time.deltaTime;
    }
    transform.position = target.position;
    transform.rotation.eulerAngles = rot;
}