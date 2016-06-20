using UnityEngine;
using System.Collections;
using UnityEngine.Networking.Types;

public class apparitionBoss : MonoBehaviour {

	private perenoelhealth vie;
	public AudioClip musique;
	private AudioSource source;
	bool once;

	void Awake()
	{
		source = GameObject.FindGameObjectWithTag ("musique").GetComponent<AudioSource> ();
	}

	void Start () 
	{
		once = true;
		vie = GameObject.FindGameObjectWithTag ("boss").GetComponent<perenoelhealth> ();

	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player" && once) 
		{
			source.Stop ();
			source.PlayOneShot (musique);
			vie.acti ();
			once = false;
			GameObject.FindGameObjectWithTag ("musique").GetComponent<mus> ().enabled = false;
		}
	}

	void Update()
	{
		if (source == null) {
			source = GameObject.FindGameObjectWithTag ("musique").GetComponent<AudioSource> ();
		}
		if (!once && !source.isPlaying) 
		{
			source.PlayOneShot (musique);
		}
	}
}
