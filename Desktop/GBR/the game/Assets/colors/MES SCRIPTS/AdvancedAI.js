var Distance;
var Target : Transform;
var lookAtDistance = 25.0;
var chaseRange = 15.0;
var attackRange = 1.5;
var moveSpeed = 5.0;
var Damping = 6.0;
var attackRepeatTime = 1;
var discret : boolean = false;

var TheDammage = 40;

private var attackTime : float;

var controller : CharacterController;
var gravity : float = 20.0;
private var MoveDirection : Vector3 = Vector3.zero;

function Start ()
{
	attackTime = Time.time;
}

function discretions(dis : boolean)
{

	discret = dis;

}

function Update ()
{
	Distance = Vector3.Distance(Target.position, transform.position);
	
	if(!discret)
	{
		if (Distance < lookAtDistance)
		{
			lookAt();
		}
	
		if (Distance < attackRange)
		{
			attack();
		}
		else if (Distance < chaseRange)
		{
			chase ();
		}
	}
}

function lookAt ()
{
	
	var rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);	
}


function chase ()
{
    GetComponent.<Animation>().Play("run");
	GetComponent.<Animation>()["run"].speed = 1;
			
	moveDirection = transform.forward;
	moveDirection *= moveSpeed;
	
	moveDirection.y -= gravity * Time.deltaTime;
	controller.Move(moveDirection * Time.deltaTime);
}

function attack ()
{
	if (Time.time > attackTime)
	{
	    GetComponent.<Animation>().Play("attack1");
	    GetComponent.<Animation>()["attack1"].speed = 2;

		Target.SendMessage("ApplyDammage", TheDammage);
		attackTime = Time.time + attackRepeatTime;
	}
}

function ApplyDammage ()
{
	chaseRange += 30;
	moveSpeed += 2;
	lookAtDistance += 40;
}