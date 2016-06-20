using UnityEngine;
using System.Collections;

public class ControlPlayerNumber : MonoBehaviour {

	private bool once;
	public int nbPlayerAuthorized = 1;

	private GameObject[] player;

	void Start () 
	{
		once = true;
		player = GameObject.FindGameObjectsWithTag("Player");
	}
	

	void Update () 
	{
		if (player.Length > nbPlayerAuthorized && once) 
		{
			Destroy(player[player.Length - 1]);
			once = false;
		}  
	}
}
