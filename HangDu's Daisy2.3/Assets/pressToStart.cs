using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressToStart : MonoBehaviour {
	private LevelManager levelManger;

	// Use this for initialization
	void Start () {
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			levelManger.LoadLevel ("LevelMenu");
		}
	}
}
