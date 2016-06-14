using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class CombatMulti : NetworkBehaviour{

	private static Dictionary<string, PlayerStatMulti> players = new Dictionary<string, PlayerStatMulti>();
	private const string PLAYER_ID_PREFIX = "Player";

	public GUIStyle InstructionBoxSkin;
	[SyncVar]
	public int deathj1 = 0;
	[SyncVar]
	public int deathj2 = 0;

	private bool score = true;
	private bool fin = false;

	void Start()
	{
		Time.timeScale = 1f;
	}

	void Update () 
	{
		if (deathj1 == 3 || deathj2 == 3) 
		{
			Death ();
		} 
	}

	public static void RegisterPlayer(string _netID, PlayerStatMulti _player)
	{
		string _playerID = PLAYER_ID_PREFIX + _netID;
		players.Add (_playerID, _player);
		_player.transform.name = _playerID;
	}

	public static void UnRegisterPlayer (string _playerID)
	{
		players.Remove (_playerID);
	}

	public static PlayerStatMulti GetPlayer(string _playerID)
	{
		return players[_playerID];
	}

	void OnGUI()
	{
		if (score) 
		{
			GUI.Label(new Rect(Screen.width-280, 15, 150, 30), "Joueur 1 : " + deathj2 + " points", InstructionBoxSkin);
			GUI.Label(new Rect(Screen.width-280, 50, 150, 30), "Joueur 2 : " + deathj1 + " points", InstructionBoxSkin);
		}
		if (fin) 
		{
			InstructionBoxSkin.fontSize = 80;
			GUI.Label(new Rect(Screen.width/4, Screen.height/2, 150, 30), "Le gagnant est le joueur : " + (deathj2 == 3 ? "1" : "2"), InstructionBoxSkin);
		}
	}

	[Client]
	void Death()
	{
		Time.timeScale = 0f;
		score = false;
		fin = true;
	}
}
