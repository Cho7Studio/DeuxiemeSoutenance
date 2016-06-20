#pragma strict

//This script allows you to insert code when the Item is used (clicked on in the inventory).

var deleteOnUse = true;

private var playersInv : Inventory;
private var item : Item;
var player : GameObject;

@script AddComponentMenu ("Inventory/Items/Item Effect")
@script RequireComponent(Item)

//This is where we find the components we need
function Awake ()
{
	playersInv = FindObjectOfType(Inventory); //finding the players inv.
	if (playersInv == null)
	{
		Debug.LogWarning("No 'Inventory' found in game. The Item " + transform.name + " has been disabled for pickup (canGet = false).");
	}
	item = GetComponent(Item);
}

//This is called when the object should be used.
function UseEffect () 
{
	//Debug.LogWarning("<INSERT CUSTOM ACTION HERE>"); //INSERT CUSTOM CODE HERE!

	if(gameObject.tag == "Clef1")
	{
			player = GameObject.Find("FPSController");
			Application.LoadLevel("Scene3");
			player.transform.position = Vector3(15.75,22.47,28.92);
	}
	if(gameObject.tag == "Clef2")
	{
			player = GameObject.Find("FPSController");
			Application.LoadLevel("Scene2");
			player.transform.position = Vector3(17.88,11.57,22.23);
	}
	if(gameObject.tag == "Clef3")
	{
			player = GameObject.Find("FPSController");
			Application.LoadLevel("Scene4");
			player.transform.position = Vector3(26.5,48.35,18.13);
	}
	if(gameObject.tag == "Clef4")
	{
			player = GameObject.Find("FPSController");
			Application.LoadLevel("Scene5");
			player.transform.position = Vector3(10.94,7.85,62.89);
	}


	//Play a sound
	playersInv.gameObject.SendMessage("PlayDropItemSound", SendMessageOptions.DontRequireReceiver);
	
	//This will delete the item on use or remove 1 from the stack (if stackable).
	if (deleteOnUse == true)
	{
		DeleteUsedItem();
	}
}

//This takes care of deletion
function DeleteUsedItem()
{
	if (item.stack == 1) //Remove item
	{
		playersInv.RemoveItem(this.gameObject.transform);
	}
	else //Remove from stack
	{
		item.stack -= 1;
	}
	//Debug.Log(item.name + " has been deleted on use");
}