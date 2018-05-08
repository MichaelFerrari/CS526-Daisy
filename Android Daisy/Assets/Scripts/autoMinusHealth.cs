using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMinusHealth : MonoBehaviour {

	public float timeToMinus = 5f;

	private float totalTime = 0;
	private GameControl gameControl;

	// Use this for initialization
	void Start() {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if (totalTime > timeToMinus) {
			gameControl.MinusHealth ();
			totalTime = 0;
		}
	}
}
