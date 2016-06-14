using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReseauNetworkManager : NetworkManager {

	public Button stop; 
	// Update is called once per frame
	void Update () 
	{

	}

	public void Local()
	{
		StartHost ();
	}

	public void Connection()
	{
		StartClient ();
	}

	public void Serveur()
	{
		StartServer ();
	}

	public void stpHost()
	{
		

			StopHost ();
					
	}

	public void stpClient()
	{
		StopClient ();
	}

	public void stpServeur()
	{
		StopServer ();
	}
}
