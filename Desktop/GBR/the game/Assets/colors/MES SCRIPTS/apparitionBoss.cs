using UnityEngine;
using System.Collections;

public class apparitionBoss : MonoBehaviour {

	private perenoelhealth vie;

	void Start () 
	{
		vie = GameObject.FindGameObjectWithTag ("boss").GetComponent<perenoelhealth> ();
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			vie.acti ();
		}
	}
}
