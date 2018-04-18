using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justVerticalMoving : MonoBehaviour {
	
	public float speed = 2f;
	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < 15.5) {
			if (!gameControl.gameOver && !pauseMenu.GameIsPaused) {
				float distance = speed * Time.deltaTime;
				transform.position += new Vector3 (0, -distance, 0);
			}
		}
//		if (!gameControl.gameOver && !pauseMenu.GameIsPaused) {
//			float distance = speed * Time.deltaTime;
//			transform.position += new Vector3 (0, -distance, 0);
//		}
	}
}
