using UnityEngine;
using System.Collections;
using System;

public class Munitions : MonoBehaviour {

	public GUISkin InstructionBoxSkin;
	PlayerStat shot;
	private bool showGUI = false;

	void Start()
	{
		shot = GameObject.FindGameObjectWithTag("pv").GetComponent<PlayerStat>();
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			showGUI = true;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			showGUI = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{ 	

		if (showGUI && Input.GetKeyDown ("e")) 
		{			
			shot.munition = shot.munition + 10;
			Destroy (gameObject);
		}
	}

	void OnGUI()
	{
		GUI.skin = InstructionBoxSkin;
		GUI.color = new Color(1f, 1f, 1f, 0.7f);

		if (showGUI) 
		{
			GUI.Box(new Rect(Screen.width*0.5f-(165*0.5f), 200, 165, 22),"Appuie sur E pour ramasser les 10 munitions");
		}
	}
}
