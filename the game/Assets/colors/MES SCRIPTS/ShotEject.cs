using UnityEngine;
using System.Collections;


public class ShotEject : MonoBehaviour {

	public Rigidbody[] bulletCasing;
	public int ejectSpeed = 50;
	public float fireRate = 0.5f;
	public int munition;
	public GUIStyle InstructionBoxSkin;

	private PlayerStat playerStats;
	private GameObject arme;
	private Rigidbody bullet;
	private float nextFire = 0.0f;
	private bool fullAuto = false;


	void Start()
	{
		playerStats = GameObject.FindGameObjectWithTag ("pv").GetComponent<PlayerStat> ();
		arme = GameObject.FindGameObjectWithTag ("ici");
		munition = playerStats.munition;
	}

	// Update is called once per frame
	void Update () 
	{
		munition = playerStats.munition;
		if (Input.GetButton("Fire1") && (munition > 0) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			bullet = (UnityEngine.Rigidbody) Instantiate (bulletCasing[(int)Random.Range (0f, (float)bulletCasing.Length)], transform.position, transform.rotation);
			arme.GetComponent<Animation>().PlayQueued ("pourri");
			playerStats.munition--;
			bullet.velocity = transform.TransformDirection (Vector3.left * ejectSpeed);
		}

		if (Input.GetButtonDown ("Fire3")) 
		{
			fullAuto = !fullAuto;
		}

		if (fullAuto) 
		{
			fireRate = 0.1f;
		} 
		else 
		{
			fireRate = 0.5f;
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width - 155, 10, 150, 30), "Cadeaux : " + munition, InstructionBoxSkin);
	}
		
}