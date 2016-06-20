using UnityEngine;
using System.Collections;

public class mus : MonoBehaviour {

	public AudioSource source;
	public AudioClip clip;

	// Use this for initialization
	void Start () 
	{
		source.PlayOneShot (clip);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!source.isPlaying) {
			source.PlayOneShot (clip);
		}
	}
}
