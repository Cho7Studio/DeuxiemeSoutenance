using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


	public int Health = 100;
	public int cadalDammage;
	private bool once;


	void Start()
	{
		once = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "cadal")
		{
			ApplyDammage(cadalDammage);
		}
	}

	public void ApplyDammage (int TheDammage)
	{
		Health -= TheDammage;

		if(Health <= 0)
		{
			gameObject.GetComponent<IA> ().enabled = false;
			if (once) {
				once = false; 
				gameObject.GetComponent<Animation> ().Play ("death");
			}
			Dead();
		}
	}

	void Dead()
	{
		Destroy (gameObject, 10f);
	}
}
