using UnityEngine;
using System.Collections;

public class Fin : MonoBehaviour {

	[SerializeField]
	public Transform platform;

	[SerializeField]
	Transform startTransform;

	public AudioClip rock;
	public AudioSource pouet;
	public bool bouge, once;
	public float platformSpeed = 1f;

	Vector3 direction;
	Transform destination;

	void Start()
	{
		once = true;
		bouge = false;
		SetDestination(startTransform);
	}

	void FixedUpdate()
	{
		if (bouge) 
		{
			this.platform.GetComponent<Rigidbody>().MovePosition (platform.position + direction* platformSpeed * Time.fixedDeltaTime);

			if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
			{
				bouge = false;
				//SetDestination(destination == startTransform ? endTransform : startTransform);
			}

			if (once) {
				music ();
				once = false;
			}

		}
	}

	void music()
	{
		
		pouet.PlayOneShot (rock);
	}

	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position -  this.platform.position).normalized;
	}
}
