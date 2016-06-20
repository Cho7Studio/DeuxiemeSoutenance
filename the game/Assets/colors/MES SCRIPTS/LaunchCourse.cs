using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LaunchCourse : MonoBehaviour {
	public GUIStyle InstructionBoxSkin;
	private bool timer, end, decom, depart;
	public GameObject arrivee;
	private GameObject[] play;
	public GameObject[] mur;
	private float startTimer, time, score, decompte, timed;
	private int minute, seconde;
	private string temps, dec;

	void Start () 
	{
		timer = false;
		end = false;
		decom = false;
		depart = false;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (!decom) 
		{
			play = GameObject.FindGameObjectsWithTag("Player");
			if (play.Length > 1) {
				decom = true;
				decompte = Time.time;
			}
		}
		if (decom && !depart) 
		{
			timed = Time.time - decompte;
		}

		if (timer) 
		{
			time = Time.time - startTimer;
			minute = Convert.ToInt32 (time) / 60;
			seconde = Convert.ToInt32 (time) % 60;
		}
		if (end) 
		{
			Time.timeScale = 0f;
		}
	}

	void OnTriggerEnter(Collider joueur)
	{
		if(joueur.gameObject.tag == "Player")
		{
			end = true;
			score = time;
			timer = false;
			Screen.lockCursor = false;
		}
	}

	void depop()
	{
		if (!timer) {
			for (int i = 0; i < mur.Length; i++) 
			{
				Destroy (mur [i]);
			}
			timer = true;
			startTimer = Time.time;
		}
	}

	void OnGUI()
	{
		if (decom && !depart) 
		{
			if (timed < 1) {
				dec = "9";
			}
			else if (timed < 2 ) {
				dec = "8";
			}
			else if (timed < 3 ) {
				dec = "7";
			}
			else if (timed < 4 ) {
				dec = "6";
			}
			else if (timed < 5 ) {
				dec = "5";
			}
			else if (timed < 6 ) {
				dec = "4";
			}
			else if (timed < 7 ) {
				dec = "3";
			}
			else if (timed < 8 ) {
				dec = "2";
			}
			else if (timed < 9 ) {
				dec = "1";
			}
			else if (timed < 10 ) {
				dec = "0";
			}
			else{
				dec = " ";
				depart = true;
				depop ();
			}
			GUI.Label(new Rect(Screen.width/2 - 83, 200, 165, 22), dec, InstructionBoxSkin);
		}
		if (timer) 
		{
			temps = minute.ToString () + " : " + seconde.ToString ();
			GUI.Label(new Rect(Screen.width - 150, 0, 165, 15), temps, InstructionBoxSkin);
		}
		if (end) 
		{
			minute = Convert.ToInt32 (score) / 60;
			seconde = Convert.ToInt32 (score) % 60;
			temps = minute.ToString () + " : " + seconde.ToString ();
			GUI.Label(new Rect(Screen.width/2 - 83, 190, 165, 22), "Meilleur temps : " + temps, InstructionBoxSkin);

			if (GUI.Button (new Rect(Screen.width/2 - 40, Screen.height/2 + 40, 165, 40),"Retour au Menu")) 
			{
				Time.timeScale = 1f;
				SceneManager.LoadScene ("MenuMulti");
			}
		}
	}
}