using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	float Distance;
	Transform Target;
	public float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	public float Damping = 6.0f;
	public float attackRepeatTime = 1f;
	public bool discret = false;
	public bool see;
	public float t;

	private PlayerStat playe;
	public int TheDammage = 40;

	float attackTime;

	public CharacterController controller;
	public float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;


	void Start ()
	{
		t = Time.time;
		see = false;
		playe = GameObject.FindGameObjectWithTag ("pv").GetComponent<PlayerStat> ();		
		Target = GameObject.FindGameObjectWithTag("pv").transform;
		attackTime = Time.time;
	}

	public void discretions(bool dis)
	{

		discret = dis;

	}

	void Update ()
	{
		Distance = Vector3.Distance(Target.position, transform.position);

		if(!discret || see)
		{
			if (Distance < lookAtDistance)
			{
				if (!see) {
					see = true;
					t = Time.time;
				}
				lookAt();
			}

			if (Distance < attackRange)
			{
				
				attack();
			}
			else if (Distance < chaseRange)
			{
				
				chase ();
			}
		} else {
			gameObject.GetComponent<Animation> ().Play ("idle");
		}
		if (see && Time.time - t > 3f) {
			see = false;
		}
	}

	void lookAt ()
	{

		var rotation = Quaternion.LookRotation(Target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);	
	}


	void chase ()
	{
		gameObject.GetComponent<Animation> ().Play ("run");
		moveDirection = gameObject.transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void attack ()
	{
		if (Time.time > attackTime)
		{
			gameObject.GetComponent<Animation> () ["attack1"].speed = 2f;
			gameObject.GetComponent<Animation> ().Play ("attack1");

			playe.ApplyDammage (TheDammage);
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void ApplyDammage ()
	{
		chaseRange += 30;
		moveSpeed += 2;
		lookAtDistance += 40;
	}
}
