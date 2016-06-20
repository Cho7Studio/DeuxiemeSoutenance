using UnityEngine;
using System.Collections;

public class ControleManadger : MonoBehaviour {

	private bool once;
	public int NombreManagerAutorises = 0;

	private GameObject[] manager;

	void Start () 
	{
		once = true;
		manager = GameObject.FindGameObjectsWithTag("manager");
	}


	void Update () 
	{
		if (manager.Length > NombreManagerAutorises && once) 
		{
			Destroy(manager[manager.Length - 1]);
			once = false;
		}  
	}
}
