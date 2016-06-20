using UnityEngine;
using System.Collections;

public class enfonceplat : MonoBehaviour {
	[SerializeField]
	public Transform platform;

	[SerializeField]
	Transform startTransform;

	[SerializeField]
	Transform endTransform;

	private bool descend, remonte;

	public float platformSpeed = 1f;

	Vector3 direction;
	Transform destination;

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Player")
		{
			descend = true;
			remonte = false;
		}
	}

	void OnTriggerExit(Collider hit)
	{

		if(hit.gameObject.tag == "Player")
		{
			descend = false;
			remonte = true;
		}
	}

	void Start()
	{
		descend = false;
		remonte = false;

		SetDestination(endTransform);
	}

	void FixedUpdate()
	{
		if (descend) 
		{
			SetDestination(endTransform);
			this.platform.GetComponent<Rigidbody>().MovePosition (platform.position + direction* platformSpeed * Time.fixedDeltaTime);
			if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
			{
				descend = false;
			}
		}
		if (remonte) {
			SetDestination(startTransform);
			this.platform.GetComponent<Rigidbody>().MovePosition (platform.position + direction* platformSpeed * Time.fixedDeltaTime);
			if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
			{
				remonte = false;
			}
		}


	}


	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position -  this.platform.position).normalized;
	}
}
