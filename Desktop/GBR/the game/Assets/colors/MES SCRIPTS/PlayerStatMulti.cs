using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerStatMulti : NetworkBehaviour 
{

	[SyncVar]
	private float Health;

	public float maxHP = 100f;
	public Texture2D HpTexture;

	private float HpLenght = 500;
	public string joueur;


	void Awake()
	{
		SetDefault ();
	}


	void Start () 
	{
		joueur = "j" + GameObject.FindGameObjectsWithTag ("Player").Length.ToString ();
		Screen.lockCursor = true;
	}

	public void SetDefault()
	{
		Health = maxHP;
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
	}

	public void ApplyDammage (int TheDammage)
	{
		Health = Health - TheDammage;
		if(Health <= 0)
		{
			CmdDead();
		}
	}


	[Command]
	void CmdDead() 
	{
		CombatMulti manager = GameObject.FindGameObjectWithTag ("CombatManager").GetComponent<CombatMulti> ();
		if (joueur == "j1") 
		{
			manager.deathj1++;
		} 
		else 
		{
			manager.deathj2++;
		}
		SetDefault ();
	}
}
