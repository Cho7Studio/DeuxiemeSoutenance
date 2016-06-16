using UnityEngine;
using System.Collections;

public class perenoelIA : MonoBehaviour {
	public Transform cible;
	public int moveSpeed = 1;
	public int rotationSpeed = 1;
	public float lookAtDistance = 20f;
	public int minDistance = 7;

	PlayerStat ptain;
	private Transform target;
	private float attackTime;
	private string nb;
	private float Distance;
	private Transform myTransform;
	public bool ok;


	void Awake()
	{
		ok = false;
		myTransform = transform;
	}

	void Start () 
	{
		cible = GameObject.FindGameObjectWithTag ("pv").transform;
		ptain = cible.GetComponent<PlayerStat> ();
		attackTime = Time.time;
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Distance = Vector3.Distance(target.position, myTransform.position);
		if (Distance <= lookAtDistance) 
		{
			Debug.DrawLine (target.position, myTransform.position);
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			if (Distance > minDistance) 
			{
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				gameObject.GetComponent<Animation>().Play ("walkforward");
			} 
			if (Distance <= minDistance) {
				gameObject.GetComponent<Animation>().Play ("roar");
				//attack ();
			}
		}
		else
		{
			if (ok) 
			{
				gameObject.GetComponent<Animation>().Play ("Idle");
			}
		}
	}
}
