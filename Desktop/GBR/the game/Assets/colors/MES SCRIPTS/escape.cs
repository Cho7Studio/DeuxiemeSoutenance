using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour {

	private bool esc;

	void Start()
	{
		esc = false;
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			esc = true;
			Screen.lockCursor = false;
		}
	}

	void OnGUI()
	{
		if (esc) {
			Time.timeScale = 0f;
			if (GUI.Button (new Rect(Screen.width/2-80, Screen.height/2 + 50, 200, 40),"Retour au Menu")) 
			{
				Time.timeScale = 1f;
				SceneManager.LoadScene ("Menu");

			}
			if (GUI.Button (new Rect(Screen.width/2-80, Screen.height/2, 200, 40),"Retour au Jeu")) 
			{
				Time.timeScale = 1f;
				esc = false;
				Screen.lockCursor = true;
			}
		} 
	}
}
