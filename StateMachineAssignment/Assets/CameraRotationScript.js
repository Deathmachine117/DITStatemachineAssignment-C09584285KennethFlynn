//Kenneth 
var target :Transform ;
 
function Update ()
{
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