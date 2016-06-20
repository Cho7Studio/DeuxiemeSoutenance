﻿using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField]
	public Transform platform;

	[SerializeField]
	Transform startTransform;

	[SerializeField]
	Transform endTransform;


	public float platformSpeed = 1f;

	Vector3 direction;
	Transform destination;

	void Start()
	{
		SetDestination(startTransform);
	}

	void FixedUpdate()
	{
		this.platform.GetComponent<Rigidbody>().MovePosition (platform.position + direction* platformSpeed * Time.fixedDeltaTime);

		if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
		{
			SetDestination(destination == startTransform ? endTransform : startTransform);
		}
	}


	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position -  this.platform.position).normalized;
	}
}