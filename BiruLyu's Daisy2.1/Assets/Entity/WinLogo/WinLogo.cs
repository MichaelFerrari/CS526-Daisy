using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogo : MonoBehaviour {

	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
		transform.position = new Vector3 (gameControl.totalDistance, transform.position.y ,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
