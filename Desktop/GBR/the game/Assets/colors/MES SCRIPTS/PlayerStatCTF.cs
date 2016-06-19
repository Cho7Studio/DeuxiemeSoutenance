using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerStatCTF : NetworkBehaviour 
{
	public GUIStyle InstructionBoxSkin;
	[SyncVar]
	private float Health;

	[SyncVar]
	public bool haveDrap;

	public float maxHP = 100f;
	public Texture2D HpTexture;

	private float HpLenght = 500;
	[SyncVar]
	public string equipe;


	void Awake()
	{
		equipe = (GameObject.FindGameObjectsWithTag ("Player").Length % 2 == 0) ? "Rouge" : "Bleue";
		SetDefault ();
	}

	void Start () 
	{
		Screen.lockCursor = true;
	}

	public void SetDefault()
	{
		Health = maxHP;
		haveDrap = false;
	}


	void Update () 
	{
		HpLenght = (Health/maxHP) * 100;
		if(Health <=0)
		{
			Health = 0;
		}
	}

	void OnGUI()
	{
		if(Health > 0)
		{
			GUI.DrawTexture (new Rect (10, 10, HpLenght, 10), HpTexture);
		}
		GUI.Label(new Rect(Screen.width-400, 15, 150, 30), "Joueur de l'équipe : " + equipe, InstructionBoxSkin);
	}

	public void ApplyDammage (int TheDammage)
	{
		Health = Health - TheDammage;
		Debug.Log ("Aie");
		if(haveDrap)
		{
			Debug.Log ("naaaaan");
			CmdDropChaussette();
		}
		if (Health <= 0) 
		{
			
		}
	}

	[Command]
	void CmdDropChaussette() 
	{
		haveDrap = false;
		CPFmulti manager = GameObject.FindGameObjectWithTag ("CTFManager").GetComponent<CPFmulti> ();
		manager.RpcspawnChaussette(this.equipe);
	}

	[Command]
	void CmdDeath()
	{
		SetDefault ();
	}
}
