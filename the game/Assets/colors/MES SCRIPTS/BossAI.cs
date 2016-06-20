using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class BossAI : MonoBehaviour {

	public Transform cible;
	public int moveSpeed = 1;
	public int rotationSpeed = 1;
	public float lookAtDistance = 5f;
	public int minDistance = 7;
	public float attackRepeatTime = 1.2f;
	public int[] dammagesDesDiversesAttaques;


	PlayerStat ptain;
	private Transform target;
	private float attackTime;
	private string nb;
	private float Distance;
	private Transform myTransform;


	void Awake()
	{
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
				gameObject.GetComponent<Animation>().Play ("run");
			} 
			if (Distance <= minDistance) {
				attack ();
			}
		}
		else
		{
			gameObject.GetComponent<Animation>().Play ("idle");

		}
	}

	void attack()
	{
		if (Time.time > attackTime) 
		{
			string nb = ((int)Random.Range (1, 4)).ToString ();
			gameObject.GetComponent<Animation> ().Play ("attack" + nb);
			attackTime = Time.time + attackRepeatTime;

			switch (nb) 
			{
			case "1":
				ptain.ApplyDammage (dammagesDesDiversesAttaques [0]);
				break;
			case "2":
				ptain.ApplyDammage (dammagesDesDiversesAttaques [1]);
				break;
			case "3":
				ptain.ApplyDammage (dammagesDesDiversesAttaques [2]);
				break;
			default:
				break;
			}
		}
	}
}
