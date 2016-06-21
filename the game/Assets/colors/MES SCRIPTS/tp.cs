using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class tp : MonoBehaviour {

	void OnTriggerEnter(Collider hit)
	{
		SceneManager.LoadScene ("SCENE FINALE");
		GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3 (-229.8f,0.61f,-13.8f);
	}
}
