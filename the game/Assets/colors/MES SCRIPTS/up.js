#pragma strict

function Update ()
{

GetComponent.<Animation>().Play("up");
GetComponent.<Animation>()["up"].speed = 1;

}