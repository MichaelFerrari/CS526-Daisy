using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeout : MonoBehaviour {
	private LevelManager levelManger;
	public float time;

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	IEnumerator Example()
	{
		yield return new WaitForSeconds(time);
		levelManger.LoadNextLevel ();

	}
}
