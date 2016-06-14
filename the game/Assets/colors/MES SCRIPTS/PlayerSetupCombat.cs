using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetupCombat : NetworkBehaviour {

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
		PlayerStatCTF _player = GetComponent<PlayerStatCTF> ();

		CPFmulti.RegisterPlayer(_netID, _player);
	}

	void AssignRemoteLayer()
	{
		gameObject.layer = LayerMask.NameToLayer(RemoteLayerName);
	}

	void OnDisable()
	{
		CPFmulti.UnRegisterPlayer (transform.name);
	}
}
