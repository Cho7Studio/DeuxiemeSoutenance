using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CPFmulti : NetworkBehaviour {

	private static Dictionary<string, PlayerStatCTF> players = new Dictionary<string, PlayerStatCTF>();
	private const string PLAYER_ID_PREFIX = "Player";

	public GameObject[] spawn;
	public GameObject[] chaussettes;

	public GameObject obj;
	public GUIStyle InstructionBoxSkin;


	void Start()
	{
		Time.timeScale = 1f;
		//RpcspawnChaussette ("Rouge");
		//RpcspawnChaussette ("Bleue");
	}

	void Update () 
	{

	}

	public static void RegisterPlayer(string _netID, PlayerStatCTF _player)
	{
		string _playerID = PLAYER_ID_PREFIX + _netID;
		players.Add (_playerID, _player);
		_player.transform.name = _playerID;
	}

	public static void UnRegisterPlayer (string _playerID)
	{
		players.Remove (_playerID);
	}

	public static PlayerStatCTF GetPlayer(string _playerID)
	{
		return players[_playerID];
	}

	void OnGUI()
	{

	}

	[ClientRpc]
	public void RpcspawnChaussette(string colorequipe)
	{
		//spawn la chaussette de l'autre couleur que celle donnée
		if (colorequipe == "Rouge") 
		{
			obj = (GameObject) Instantiate (chaussettes[0], spawn[0].transform.position, spawn[0].transform.rotation);
		} 
		else if(colorequipe == "Bleue") 
		{
			obj = (GameObject) Instantiate (chaussettes[1], spawn[1].transform.position, spawn[1].transform.rotation);
		} 
		NetworkServer.Spawn (obj);
	}

	[Client]
	void Death()
	{
		Time.timeScale = 0f;
	}
}
