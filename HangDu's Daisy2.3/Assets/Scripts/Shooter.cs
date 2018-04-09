using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	public GameObject projectile;
	public float fireRate = 2f;
	public float xPosOffset = 1;
	public float yPosOffset = 0;
	private float timeCount = 0;
//	private float xmin = 0;
	private float xmax = 0;
	private GameControl gameControl;

	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
//		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
//		xmin = leftMost.x;
		xmax = rightMost.x;
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver) {
			if (transform.position.x <= xmax) {
				timeCount += Time.deltaTime;
				if (timeCount > fireRate) {
					Fire ();
					timeCount = 0;
				}
			}
		}
	}

	private void Fire() {
		Vector3 offSet = new Vector3 (-xPosOffset, yPosOffset, 0);
		Instantiate (projectile, transform.position + offSet, Quaternion.identity);
	}
}
