#pragma strict

function Update ()
{

GetComponent.<Animation>().Play("translation");
GetComponent.<Animation>()["translation"].speed = 0.8;

}