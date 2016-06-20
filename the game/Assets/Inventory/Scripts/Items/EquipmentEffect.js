#pragma strict

//This script allows you to create equipment effects that will be called either OnEquip or WhileEquipped. This is usefull for magic effects and stat handling.

@script AddComponentMenu ("Inventory/Items/Equipment Effect")
@script RequireComponent(Item)

private var showGUI = false;
private var effectActive = false;

function Update () 
{
	if (effectActive == true)
	{
		

		//-----> THIS IS WHERE YOU INSERT CODE YOU WANT TO EXECUTE AS LONG AS THE ITEM IS EQUIPPED. <-----
	}
}

function OnGUI()
{
	if(showGUI)
	{
		GUI.Label(Rect(Screen.width/2,Screen.height/2,200,200),"+");
	}
}

function EquipmentEffectToggle (effectIs : boolean)
{
	if (effectIs == true)
	{
		effectActive = true;
		
		//Debug.LogWarning("Remember to insert code for the EquipmentEffect script you have attached to " + transform.name + ".");
		if(gameObject.tag == "regeneration")
		{
			GameObject.Find("cible").SendMessage("activeRegen", true);
		}
		if(gameObject.tag == "vitesse")
		{
			GameObject.Find("FPSController").SendMessage("ActiveVitesse", true);
		}
		if(gameObject.tag == "saut")
		{
			GameObject.Find("FPSController").SendMessage("ActiveSaut", true);
		}
		if(gameObject.tag == "croix")
		{

			showGUI = true;
		}
		if(gameObject.tag == "resistance")
		{
			GameObject.Find("cible").SendMessage("activeResistance", true);
		}
		if(gameObject.tag == "discretion")
		{

			GameObject.Find("FPSController").SendMessage("discretion", true);
		}
		
		//-----> THIS IS WHERE YOU INSERT CODE YOU WANT TO EXECUTE JUST WHEN THE ITEM IS EQUIPPED. <-----	
	}
	else
	{
		effectActive = false;
		if(gameObject.tag == "regeneration")
		{
			GameObject.Find("cible").SendMessage("activeRegen", false);
		}
		if(gameObject.tag == "vitesse")
		{
			GameObject.Find("FPSController").SendMessage("ActiveVitesse", false);
		}
		if(gameObject.tag == "saut")
		{
			GameObject.Find("FPSController").SendMessage("ActiveSaut", false);
		}
		if(gameObject.tag == "croix")
		{
			showGUI = false;
		}
		if(gameObject.tag == "resistance")
		{
			GameObject.Find("cible").SendMessage("activeResistance", false);
		}
		if(gameObject.tag == "discretion")
		{
			GameObject.Find("FPSController").SendMessage("discretion", false);
		}
		//-----> THIS IS WHERE YOU INSERT CODE YOU WANT TO EXECUTE JUST WHEN THE ITEM IS UNEQUIPPED. <-----
	}
}