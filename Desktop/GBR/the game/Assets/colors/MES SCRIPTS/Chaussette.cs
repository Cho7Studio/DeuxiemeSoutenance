using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Chaussette : NetworkBehaviour {

	public string couleur;
	public GUISkin InstructionBoxSkin;

	private bool showGUI = false;
	private bool ramassable = false;
	private GameObject player;
	// Use this for initialization

	public void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player" && hit.gameObject.GetComponent<PlayerStatCTF>().equipe != couleur) 
		{
			ramassable = true;
			player = hit.gameObject;
			RpcChaussette ();
		}
	}
		
	// Update is called once per frame

	[ClientRpc]
	void RpcChaussette()
	{
		player.GetComponent<PlayerStatCTF>().haveDrap = true;
		Debug.Log ("hohohoho");
		Destroy (gameObject);
	}

}
