using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	public float rotateSpeed = 10;
	private GameControl gameControl;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pauseMenu.GameIsPaused && !gameControl.gameOver) {
			var rotationVector = transform.rotation.eulerAngles;
			rotationVector.z += rotateSpeed;
			transform.rotation = Quaternion.Euler(rotationVector);
		}
	}
}
