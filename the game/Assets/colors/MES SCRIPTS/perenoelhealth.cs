using UnityEngine;
using System.Collections;

public class perenoelhealth : MonoBehaviour {
	private bool activation, once, mortt;
	float time;
	public float Health = 1000f;
	public AudioSource source;
	public AudioClip mort;
	private perenoelIA scrip;
	private Fin rock;

	// Use this for initialization
	void Start () 
	{
		rock = GameObject.FindGameObjectWithTag ("rock").GetComponent<Fin> ();
		once = true;
		mortt = true;
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
			Dead ();
		}
	}

	void Dead()
	{
		if (mortt) {
			mortt = false;
			gameObject.GetComponent<Animation> ().Play ("Die");
			source.PlayOneShot (mort);
			Destroy (gameObject,60f);
			StartCoroutine (rockk());
		}
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

	IEnumerator rockk()
	{
		yield return new WaitForSeconds (15f);
		rock.bouge = true;
	}
}
