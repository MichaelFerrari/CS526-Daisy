using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justMoving : MonoBehaviour {

	public float speed = 2f;
	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver && !gameControl.gameEnd) {
			float distance = speed * Time.deltaTime;
			transform.position += new Vector3 (-distance, 0);
		}
	}
}
