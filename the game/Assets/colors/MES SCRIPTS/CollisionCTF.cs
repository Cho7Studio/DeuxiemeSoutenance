using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CollisionCTF : NetworkBehaviour {

	public string equipe;
	PlayerStatCTF playe;
	bool fin = false;
	public GUIStyle InstructionBoxSkin;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") {
			playe = hit.gameObject.GetComponent <PlayerStatCTF> ();
			if (playe.equipe == equipe && playe.haveDrap) {
				Rpctermine ();
			}
		}
	}

	void OnGUI()
	{
		if (fin) 
		{
			InstructionBoxSkin.fontSize = 50;
			GUI.Label(new Rect(Screen.width/4, Screen.height/2, 150, 30), "l'équipe gagnante est la : " + equipe, InstructionBoxSkin);
		}
	}

	[ClientRpc]
	void Rpctermine()
	{
		Time.timeScale = 0f;
		Screen.lockCursor = false;
		fin = true;
	}
}
