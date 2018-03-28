using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
	public bool destroy = false;
	public int damage = 1;
	public float speed = 2f;
	public AudioClip crack;

	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver) {
			float distance = speed * Time.deltaTime;
			transform.position += new Vector3 (-distance, 0);
		}

		if (transform.position.x < -50) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
	}
}
