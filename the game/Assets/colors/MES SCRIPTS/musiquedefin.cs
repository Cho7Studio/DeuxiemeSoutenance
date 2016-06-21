using UnityEngine;
using System.Collections;

public class musiquedefin : MonoBehaviour {

	public AudioClip music;
	AudioSource source;
	bool one;
	// Use this for initialization
	void Start () 
	{
		one = true;
		source = GameObject.FindGameObjectWithTag ("musique").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (source == null) {
			source = GameObject.FindGameObjectWithTag ("musique").GetComponent<AudioSource> ();
		}
		if (one) {
			once ();
		}
		if (!source.isPlaying) {
			source.PlayOneShot (music);
		}

	}

	void once()
	{
		source.Stop ();
		one = false;
	}
}
