using UnityEngine;
using System.Collections;

public class bouchecible : MonoBehaviour {
	perenoelhealth vie;
	public int cadaldammage = 50;

	void Start () {
		vie = gameObject.GetComponentInParent<perenoelhealth> ();
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "cadal") 
		{
			vie.ApplyDammage (cadaldammage);
			Debug.Log ("touché");
		}
	}
}
