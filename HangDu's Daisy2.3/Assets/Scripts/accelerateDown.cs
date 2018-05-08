using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerateDown : MonoBehaviour {

	private float lastVelocity = 0f;
	public float curAccelerate = 0f;
	public bool verticalOrHorizontal = true;
	public float verticalSpeed = 2f;

	private PlayControl playControl;
	private bool isMoving;

	// Use this for initialization
	void Start () {
		lastVelocity = 0;
		playControl = GameObject.FindObjectOfType<PlayControl>();
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - playControl.transform.position.x < 24) {
			isMoving = true;
		} 

		if (isMoving) {
			double distance = lastVelocity * Time.deltaTime + 0.5 * curAccelerate * Time.deltaTime * Time.deltaTime;
			if (verticalOrHorizontal) {
				transform.position += new Vector3 (0, (float)-distance, 0);
			} else {
				transform.position += new Vector3 ((float)-distance, 0);
			}
			lastVelocity += curAccelerate * Time.deltaTime;

			float newDistance = verticalSpeed * Time.deltaTime;
			transform.position += new Vector3 (0, -newDistance, 0);
		}
	}
}
