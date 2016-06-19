using UnityEngine;
using System.Collections;

public class boddeath : MonoBehaviour {

	public Animation mort;
	private bool act = true;

	void Update()
	{
		if (act) 
		{
			mort.Play("death");
			act = false;
		}
	}

}
