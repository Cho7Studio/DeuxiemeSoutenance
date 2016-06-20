
#pragma strict

var InstructionBoxSkin : GUISkin;
var clef : Rigidbody;
private var showGUI : boolean = false;
private var aramasser : boolean = true;


function OnTriggerEnter(hit : Collider)
{
	if(hit.gameObject.tag == "Player")
	{
		showGUI = true;
	}
}

function OnTriggerExit(hit : Collider)
{
	if(hit.gameObject.tag == "Player")
	{
		showGUI = false;
	}
}

function Update () 
{
	if(aramasser && showGUI && Input.GetKeyDown("e"))
	{
		Loot();
		GameObject.FindGameObjectWithTag("prisonier").GetComponent(PopClef).enabled = false;
	}
}

function Loot()
{
	aramasser = false;
	var clefaramasser : Rigidbody;
	clefaramasser = Instantiate(clef, transform.position, transform.rotation);

}

function OnGUI()
{
	if(showGUI && aramasser)
	{
		GUI.skin = InstructionBoxSkin;
	    GUI.color = Color(1, 1, 1, 0.7);
		
		GUI.Box(Rect(Screen.width*0.5-(165*0.5), 200, 165, 22),"Appuie sur E pour intéragir avec le prisonnier");
	}
}