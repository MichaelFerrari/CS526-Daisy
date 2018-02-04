using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMove : MonoBehaviour {
	public float reversePeriod = 5f;
	public float reverseDistance = 3f;
	public float reverseSpeed = 4f;

	private float xmin = 0;
	private float xmax = 0;

	private bool reverse = false;
	private float periodSum;
	private float endReverse;

	private GameControl gameControl;

	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		xmin = leftMost.x;
		xmax = rightMost.x;
		gameControl = GameObject.FindObjectOfType<GameControl> ();

		periodSum = reversePeriod;
		endReverse = periodSum - reverseDistance;
	}

	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver) {
			if (transform.position.x <= xmax && transform.position.x >= xmin) {
				float currentDistance = -transform.position.x + xmax;
				if (!reverse && currentDistance > periodSum) {
					reverse = true;
					endReverse = periodSum - reverseDistance;
				}
				if (reverse) {
					if (currentDistance > endReverse) {
						reverseMove ();
					} else {
						reverse = false;
						periodSum += reversePeriod;
					}
				}
			}
		}
	}

	private void reverseMove() {
		float distance = reverseSpeed * Time.deltaTime;
		transform.position += new Vector3 (distance, 0);
	}
}
