using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public Sprite[] healthBar;
	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (gameControl.health);
		GetComponent<SpriteRenderer>().sprite = healthBar[gameControl.health];
	}
}
