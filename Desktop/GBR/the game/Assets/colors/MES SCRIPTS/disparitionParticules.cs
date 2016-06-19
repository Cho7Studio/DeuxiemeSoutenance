using UnityEngine;
using System.Collections;

public class disparitionParticules : MonoBehaviour {

	private bool aie = false;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			aie = true;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			aie = false;
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (aie && Input.GetKeyDown ("e")) 
		{
			Destroy (gameObject);
		}
	}
}
