﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingSpawner : MonoBehaviour {
	public PlayControl player;
	private SpriteRenderer sprite;
	private float horizontalDistance = 8f;
	private float verticalDistance = 0f;
	private float yValue;
	private float transparency = 1f;
	bool isForward, isUp, isActive;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayControl>();
		sprite = gameObject.GetComponent<SpriteRenderer>();
		yValue = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (!pauseMenu.GameIsPaused) {
			if ((transform.position.x - player.transform.position.x) < 8) {
				isActive = true;
			}
			if (isActive) {
				if (isForward) {
					horizontalDistance += 0.1f;
				} else {
					horizontalDistance -= 0.1f;
				}
				if (isUp) {
					verticalDistance += 0.08f;
				} else {
					verticalDistance -= 0.08f;
				}
				transform.position = new Vector3 (player.transform.position.x + horizontalDistance, yValue + verticalDistance, player.transform.position.z);
				if (horizontalDistance >= 8) {
					isForward = false;
				} else if (horizontalDistance <= -8) {
					isForward = true;
				}
				if (verticalDistance >= 5) {
					isUp = false;
				} else if (verticalDistance <= -5) {
					isUp = true;
				}
				transparency -= 0.0005f;
				sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, transparency);
				if (transparency <= 0.4) {
					Destroy (gameObject);
				}
			} else {
				transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, player.transform.position.z);
			}
		}
	}

}