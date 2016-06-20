using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class tp : MonoBehaviour {

	void OnTriggerEnter(Collider hit)
	{
		SceneManager.LoadScene ("Niveau 6");
	}
}
