using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {
	private float padding = 1f;
	private float xmin;
	private float xmax;
	private Rigidbody2D rigi;
	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));

		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;

		rigi = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				rigi.AddForce (new Vector2 (0, gameControl.playerForce));
			}

			if (Input.GetKeyDown (KeyCode.A)) {
				rigi.velocity = new Vector2 (-gameControl.playerSpeed, 0);
			} else if (Input.GetKeyDown (KeyCode.D)) {
				rigi.velocity = new Vector2 (gameControl.playerSpeed, 0);
			}
			float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (gameControl.gameOver) {
			gameControl.goToLose ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		MovingObject movingObject = collider.gameObject.GetComponent<MovingObject>();
		if (movingObject != null) {
			int count = movingObject.damage;
			if (count < 0) {
				gameControl.AddHealth (count);
			} else {
				gameControl.Hurt (count);
			}
			if (movingObject.destroy) {
				Destroy (collider.gameObject);
			}
		}
	}
}
