using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour {

	static float lastVelocity = 0f;
	public float curAccelerate = 0f;
	public bool verticalOrHorizontal = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		double distance = lastVelocity * Time.deltaTime + 0.5 * curAccelerate * Time.deltaTime * Time.deltaTime;
		if (verticalOrHorizontal) {
			transform.position += new Vector3 (0, (float)-distance, 0);
		} else {
			transform.position += new Vector3 ((float)-distance, 0);
		}
		lastVelocity += curAccelerate * Time.deltaTime;
	}
}
