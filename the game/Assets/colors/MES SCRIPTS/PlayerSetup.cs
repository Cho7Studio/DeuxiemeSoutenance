using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;

public class PlayerSetup : NetworkBehaviour 
{
	[SerializeField]
	Behaviour[] componentsToDisable;

	[SerializeField]
	string RemoteLayerName = "RemotePlayer";

	void Start()
	{
		if (!isLocalPlayer) 
		{
			DisableComponent ();
			AssignRemoteLayer ();
		}
	}

	void DisableComponent()
	{
		for (int i = 0; i < componentsToDisable.Length; i++) 
		{
			componentsToDisable [i].enabled = false;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();

		string _netID = GetComponent<NetworkIdentity> ().netId.ToString ();
		PlayerStatMulti _player = GetComponent<PlayerStatMulti> ();

		CombatMulti.RegisterPlayer(_netID, _player);
	}

	void AssignRemoteLayer()
	{
		gameObject.layer = LayerMask.NameToLayer(RemoteLayerName);
	}

	void OnDisable()
	{
		CombatMulti.UnRegisterPlayer (transform.name);
	}
}
