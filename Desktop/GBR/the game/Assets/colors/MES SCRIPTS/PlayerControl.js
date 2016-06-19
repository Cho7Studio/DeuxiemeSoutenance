#pragma strict

private var hasAxe : boolean = false;

private var canSwing : boolean = true;
private var isSwinging : boolean = false;
var swingTimer : float = 0.7;

private var controller : CharacterController;
function Start()
{
	hasAxe = true;
	//controller = GameObject.Find("FPSController").GetComponent(CharacterController);
	controller = GameObject.FindWithTag("Player").GetComponent(CharacterController);
}

function Update()
{
	//HIT SECTION
	if(hasAxe == true && canSwing == true)
	{
		if(Input.GetMouseButtonDown(0))
		{			
			//Swinging animation
			GetComponent.<Animation>().Play("hit");
			GetComponent.<Animation>()["hit"].speed = 1.8;
			isSwinging = true;
			canSwing = false;
		}
	}
	
	if(canSwing == false)
	{
		swingTimer -= Time.deltaTime;
	}
	
	if(swingTimer <= 0)
	{
		swingTimer = 0.5;
		canSwing = true;
		isSwinging = false;
	}
}

















