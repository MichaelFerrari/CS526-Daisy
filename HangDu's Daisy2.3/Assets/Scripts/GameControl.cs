using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
	public characterBlink flowerblinker;
    public characterBlink arm1blinker;
    public characterBlink arm2blinker;
    public characterBlink legblinker;
    public characterBlink bodyblinker;
    public characterBlink headblinker;
    public characterBlink leftshoeblinker;
    public characterBlink rightshowblinker;

    public float BackGroundScrollSpeed = 2f;
	public float BackGroundScrollLength = 32f;

	public float totalDistance = 10f;

	public float playerSpeed = 10f;
	public float playerForce = 25f;

	public int health = 16;
	public bool gameOver = false;
	public bool gameEnd = false;

	public Text healthText;

	private LevelManager levelManger;
	private int totalHealth;

	private PlayControl playControl;
	private float totalTime = 0f;


	// Use this for initialization
	void Start () {
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
		playControl = GameObject.FindObjectOfType<PlayControl> ();
		healthText.text = "Health: " + health.ToString();
		totalHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if (playControl.gameObject.layer == 10) {
			totalTime += Time.deltaTime;
			if (totalTime >= 1.5f) {
				totalTime = 0;
				playControl.gameObject.layer = 9;

				PlayControl.movingObject = null;
			}
		}
	}

	public void GameWin() {
		levelManger.LoadNextLevel ();
	}

	public void AddHealth(int cure) {
		if (!gameOver) {
			health -= cure;
			if (health >= totalHealth) {
				health = totalHealth;
			}
			healthText.text = "Health: " + health.ToString();
		}
	}

	public void MinusHealth() {
		health-- ;
		if (health <= 0) {
			health = 0;
			GameOver ();
		}

		healthText.text = "Health: " + health.ToString();
	}

	public void Hurt(int damage) {
		flowerblinker.startblinking ();
		arm1blinker.startblinking ();
		arm2blinker.startblinking ();
		legblinker.startblinking ();
		bodyblinker.startblinking ();
		headblinker.startblinking ();
		leftshoeblinker.startblinking ();
		rightshowblinker.startblinking ();
		health -= damage;
		if (health <= 0) {
			health = 0;
			GameOver ();
		}
		healthText.text = "Health: " + health.ToString ();
		playControl.gameObject.layer = 10;
	}

	private void GameOver() {
		gameOver = true;
		//levelManger.LoadLevel ("Lose Screen");
	}

	public void goToLose() {
		levelManger.LoadLevel ("Lose Screen");
	}
}
