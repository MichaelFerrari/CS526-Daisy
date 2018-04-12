using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWin : MonoBehaviour {
	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		gameControl.GameWin ();
	}
}
