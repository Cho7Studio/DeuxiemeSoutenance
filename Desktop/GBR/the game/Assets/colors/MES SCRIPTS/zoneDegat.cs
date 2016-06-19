using UnityEngine;
using System.Collections;

public class zoneDegat : MonoBehaviour {

	//public GameObject zone;
	public int Dammages = 5;
	public float delai = 1;

	private float temps;
	private bool aie;
	private PlayerStat stat;

	void Start()
	{
		stat = GameObject.FindGameObjectWithTag ("pv").GetComponent<PlayerStat>();
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			aie = true;
			temps = Time.time;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if (hit.gameObject.tag == "Player") 
		{
			aie = false;
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (aie && (Time.time - temps) > delai) 
		{
			stat.ApplyDammage (Dammages);
			temps = Time.time;
		}
	}
}
