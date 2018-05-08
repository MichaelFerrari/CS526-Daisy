using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreSpeed : MonoBehaviour {
	private GameControl gameControl;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 20) {
			if (!gameControl.gameOver && !pauseMenu.GameIsPaused) {
				float distance = speed * Time.deltaTime;
				transform.position += new Vector3 (-distance, 0, 0);
			}
		}
	}
}
