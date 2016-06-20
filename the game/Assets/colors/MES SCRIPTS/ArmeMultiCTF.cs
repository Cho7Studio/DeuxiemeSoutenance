using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ArmeMultiCTF : NetworkBehaviour {


	public int damage = 25;
	public float maxDistance = 2f;
	public float damageDelay = 0.6f;
	public float swingTimer = 0.7f;
	public Camera cam;

	private const string PLAYER_TAG = "Player";
	private bool isSwinging = false;
	private bool canSwing = true;
	[SerializeField]
	private LayerMask mask;


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") && canSwing == true)
		{
			Damage ();
			isSwinging = true;
			canSwing = false;
		}

		if(canSwing == false)
		{
			swingTimer -= Time.deltaTime;
		}

		if(swingTimer <= 0)
		{
			swingTimer = 0.5f;
			canSwing = true;
			isSwinging = false;
		}
	}

	[Client]
	private void Damage()
	{
		RaycastHit _hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, maxDistance, mask)) 
		{
			if (_hit.collider.tag == PLAYER_TAG) 
			{
				CmdPlayerHit (_hit.collider.name, damage);	
			}
		}
	}
		

	[Command]
	void CmdPlayerHit(string _playerID, int damage)
	{
		PlayerStatCTF _player = CPFmulti.GetPlayer (_playerID);
		_player.ApplyDammage (damage);
	}
}
