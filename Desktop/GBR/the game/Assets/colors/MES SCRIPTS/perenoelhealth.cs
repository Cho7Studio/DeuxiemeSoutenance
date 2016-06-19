using UnityEngine;
using System.Collections;

public class perenoelhealth : MonoBehaviour {
	private bool activation, once;
	float time;
	public float Health = 1000f;
	private perenoelIA scrip;

	// Use this for initialization
	void Start () 
	{
		once = true;
		activation = true;
		scrip = gameObject.GetComponent<perenoelIA> ();
		gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		gameObject.GetComponentInChildren<MeshRenderer> ().enabled = false;
	}
	
	public void acti()
	{
		if (activation) {
			activation = false;

			gameObject.GetComponent<Animation> ().Play ("Spawn");
			time = Time.time;
		}
	}

	public void ApplyDammage(int TheDammage)
	{
		Health -= TheDammage;

		if(Health <= 0)
		{
			GameObject.Find ("creature1").GetComponent<perenoelIA> ().enabled = false;
			gameObject.GetComponent<Animation> ().Play ("Die");
			Dead ();
		}
	}

	void Dead()
	{
		Destroy (gameObject,60f);
	}

	void Update () 
	{
		if (!activation && Time.time - time > 0.2f && once) 
		{
			once = false;
			gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
			gameObject.GetComponentInChildren<MeshRenderer> ().enabled = true;
		}
		if (!activation && Time.time - time > 2f && !scrip.ok) 
		{
			scrip.ok = true;
		}
	}
}
