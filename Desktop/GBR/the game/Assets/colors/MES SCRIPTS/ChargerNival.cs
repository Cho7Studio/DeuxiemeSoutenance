using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChargerNival : MonoBehaviour {

	public void Niveau1()
	{
		SceneManager.LoadScene ("Scene.1");
	}

	public void Niveau2()
	{
		SceneManager.LoadScene ("Scene 3");
	}

	public void Niveau3()
	{
		SceneManager.LoadScene ("Scene2");
	}

	public void Niveau4()
	{
		SceneManager.LoadScene ("Scene 4");
	}

	public void Niveau5()
	{
		SceneManager.LoadScene ("Scene 5");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
