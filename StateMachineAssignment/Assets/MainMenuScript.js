//Kenneth Flynn C09584285
//This means when the mouse enters the trigger it will turn red
function OnMouseEnter() 
{
	renderer.material.color = Color.red; //change the color of the text
}
//This means when the mouse leaves it will return to a white color
function OnMouseExit()
{ 
renderer.material.color = Color.white; //change the colorï»¿ of the text
 
}
//This means that when the mouse is clicked it will load level 1
function OnMouseUp()
{
    //This loads level 1
    Application.LoadLevel("Level1");  
}