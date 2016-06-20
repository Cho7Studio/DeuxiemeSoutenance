using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine.Networking;
using System.Configuration;

public class ArmeMulti : NetworkBehaviour {

	public GameObject[] bulletCasing;
	public float fireRate = 1f;
	public GameObject canon;
	public Camera cam;
	public int damage = 25;
	public float range = 100f;

	private const string PLAYER_TAG = "Player";
	private Rigidbody bullet;
	private float nextFire = 0.0f;
	[SerializeField]
	private LayerMask mask;


	void Update () 
	{

		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			Shoot (); 
			CmdShoot ();
			nextFire = Time.time + fireRate;
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect(Screen.width/2,Screen.height/2,200,200), "+");
	}


	[Client]
	private void Shoot()
	{
		RaycastHit _hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, range, mask)) 
		{
			if (_hit.collider.tag == PLAYER_TAG) 
			{
				CmdPlayerShot (_hit.collider.name, damage);	
			}
		}
	}

	[Command]
	public void CmdShoot()
	{
		GameObject obj = (GameObject)Instantiate (bulletCasing [(int)Random.Range (0f, (float)bulletCasing.Length)], canon.transform.position, canon.transform.rotation);
		Destroy (obj,5.0f);
		NetworkServer.Spawn (obj);
	}

	[Command]
	void CmdPlayerShot(string _playerID, int damage)
	{
		PlayerStatMulti _player = CombatMulti.GetPlayer (_playerID);
		_player.ApplyDammage (damage);
	}
}