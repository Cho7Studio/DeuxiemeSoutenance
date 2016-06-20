#pragma strict

function Update()
{
	transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);
}