using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
	public characterBlink blinker;
	public float BackGroundScrollSpeed = 2f;
	public float BackGroundScrollLength = 32f;

	public float totalDistance = 10f;

	public float playerSpeed = 10f;
	public float playerForce = 25f;

	public int health = 16;
	public bool gameOver = false;

	public Text healthText;

	private LevelManager levelManger;

	// Use this for initialization
	void Start () {
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
		healthText.text = "Health: " + health.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GameWin() {
		levelManger.LoadNextLevel ();
	}

	public void AddHealth(int cure) {
		if (!gameOver) {
			health -= cure;
			if (health >= 16) {
				health = 16;
			}
			healthText.text = "Health: " + health.ToString();
		}
	}

	public void Hurt(int damage) {
		blinker.startblinking();
		health -= damage;
		if (health <= 0) {
			health = 0;
			GameOver ();
		}

		healthText.text = "Health: " + health.ToString();
	}

	private void GameOver() {
		gameOver = true;
		//levelManger.LoadLevel ("Lose Screen");
	}

	public void goToLose() {
		levelManger.LoadLevel ("Lose Screen");
	}
}
