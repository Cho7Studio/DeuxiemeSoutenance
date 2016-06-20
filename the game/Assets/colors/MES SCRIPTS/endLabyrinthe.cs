using UnityEngine;
using System.Collections;

public class endLabyrinthe : MonoBehaviour {

	public AudioSource musique;
	public AudioClip haha;
	bool play = true;

	void OnTriggerEnter(Collider muuur)
	{
		if (muuur.gameObject.tag == "Player" && play) 
		{
			play = false;
			musique.PlayOneShot (haha,0.7f);
		}
	}
}
