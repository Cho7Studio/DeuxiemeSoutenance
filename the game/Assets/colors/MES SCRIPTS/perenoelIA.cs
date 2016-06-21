using UnityEngine;
using System.Collections;

public class perenoelIA : MonoBehaviour {
	public Transform cible;
	public int moveSpeed = 1;
	public int rotationSpeed = 1;
	public float lookAtDistance = 20f;
	public int minDistance = 7;
	public GameObject particule;
	public int degat2, degat3;
	public AudioSource source;
	public AudioClip[] clip;

	private Transform init;
	private bool lance, wait;
	private int nb;
	private PlayerStat ptain;
	private Transform target;
	private float attackTime, timeatta, timegrr;
	private float Distance;
	private Transform myTransform;
	public bool ok;


	void Awake()
	{
		lance = false;
		ok = false;
		myTransform = transform;
	}

	void Start () 
	{
		wait = true;
		init = GameObject.FindGameObjectWithTag ("atta").transform;
		cible = GameObject.FindGameObjectWithTag ("pv").transform;
		ptain = cible.GetComponent<PlayerStat> ();
		attackTime = Time.time;
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		timegrr = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Distance = Vector3.Distance(target.position, myTransform.position);
		if (Distance <= lookAtDistance) 
		{
			Debug.DrawLine (target.position, myTransform.position);
			if (!source.isPlaying && wait) 
			{
				wait = false;
				timegrr = Time.time;
				source.PlayOneShot (clip[(int)Random.Range (0,3)]);
			}
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			if (Distance > minDistance) 
			{
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				gameObject.GetComponent<Animation>().Play ("walkforward");
			} 
			if (Distance <= minDistance && !lance) 
			{
				gameObject.GetComponent<Animation>().Play ("roar");

				if (!source.isPlaying && wait) 
				{
					source.PlayOneShot (clip[5]);
					wait = false;
					timegrr = Time.time;
				}
				StartCoroutine (attack ());
			}
		}
		else if (!lance && ok)
		{
			gameObject.GetComponent<Animation>().Play ("Idle");
		}

		if (!wait && Time.time - timegrr > 3f) 
		{
			wait = true;
		}
		if (lance && Time.time - timeatta > 3f) 
		{
			lance = false;
		}
	}
		

	public IEnumerator attack()
	{
		lance = true;
		timeatta = Time.time;
		yield return new WaitForSeconds (1f);

		nb = ((int)Random.Range (1, 101));
		if (nb < 50) 
		{
			gameObject.GetComponent<Animation>().Play("Attack2");
			ptain.ApplyDammage (degat2);
		}
		else if (nb < 85) 
		{
			gameObject.GetComponent<Animation>().Play("Attack3");
			ptain.ApplyDammage (degat3);

		}
		else 
		{
			gameObject.GetComponent<Animation>().Play("Attack1");
			Instantiate (particule,init.position,init.rotation);
		}
	}

	public void st()
	{
		gameObject.GetComponent<Animation> ().Stop ();
	}
}
