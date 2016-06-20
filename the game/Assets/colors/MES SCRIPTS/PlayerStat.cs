using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class PlayerStat : MonoBehaviour {

	public float Health = 100f;
	public float maxHP = 100f;
	public Texture2D HpTexture;
	public int munition = 30;
	public int maxMunition = 100;
	public int cadalDammage;
	//var hitsound : AudioClip;

	private float HpLenght = 500;
	private bool regen = false;


	void Start () 
	{
		Screen.lockCursor = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "cadal") 
		{
			ApplyDammage (cadalDammage);
		}
	}

	void Update () 
	{

		HpLenght = (Health/maxHP) * 100;
		if(Health <=0)
		{
			Health = 0;
		}

		if (regen && Health < maxHP && Health > 0) 
		{
			Health += Time.deltaTime * 4;
			if (Health > maxHP) 
			{
				Health = maxHP;
			}
		}
		munition = munition;
		if (munition > maxMunition) 
		{
			munition = maxMunition;
		}
	}

	void activeRegen(bool act)
	{
		regen = act;
	}

	void activeResistance(bool act)
	{
		if (act) 
		{
			maxHP = 700f;
			Health += 600f;
		}
		else 
		{
			maxHP = 100f;
			if (Health > 100f) 
			{
				Health = 90f;
			}
		}
	}

	void OnGUI()
	{
		if(Health > 0)
		{
			GUI.DrawTexture (new Rect (10, 10, HpLenght, 10), HpTexture);
		}
	}

	public void ApplyDammage (int TheDammage)
	{
		Health = Health - TheDammage;
		//GetComponent.<AudioSource>().PlayOneShot(hitsound);
		if(Health <= 0)
		{
			Dead();
		}

	}

	void Dead() 
	{
		SceneManager.LoadScene ("GameOver");
	}
}
