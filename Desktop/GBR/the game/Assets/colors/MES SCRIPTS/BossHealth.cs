using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public float Health = 500f;
	public string EnemyName;
	public int cadalDammage;
	public GameObject plat;

	void Awake()
	{
		plat.GetComponent<MeshRenderer> ().enabled = false;
		MeshRenderer[] lol  = plat.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < lol.Length; i++) 
		{
			lol[i].enabled = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "cadal") 
		{
			ApplyDammage (cadalDammage);
		}
	}

	void ApplyDammage(int TheDammage)
	{
		Health -= TheDammage;

		if(Health <= 0)
		{
			GameObject.Find (EnemyName).GetComponent<BossAI> ().enabled = false;
			gameObject.GetComponent<Animation> ().Play ("death");
			Dead ();
		}
	}

	void Dead()
	{
		plat.GetComponent<MeshRenderer> ().enabled = true;
		MeshRenderer[] lol = plat.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < lol.Length; i++) 
		{
			lol[i].enabled = true;
		}
		Destroy (gameObject,30f);
	}
		
}