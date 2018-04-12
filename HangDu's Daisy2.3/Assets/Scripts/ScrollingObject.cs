using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
	
	public float totalDistance;
	public PlayControl player;
	private GameControl gameControl;

	// Use this for initialization
	void Start () 
	{	
		player = GameObject.FindObjectOfType<PlayControl>();
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}

	void Update()
	{
		if (!gameControl.gameOver && !gameControl.gameEnd) {
			float distance = gameControl.BackGroundScrollSpeed * Time.deltaTime;
			totalDistance += distance;
			transform.position += new Vector3 (-distance, 0);
			if (totalDistance > gameControl.totalDistance - 8f) {
				gameControl.gameEnd = true;
			}
		}
		if (!gameControl.gameOver && gameControl.gameEnd) {
			float distance = gameControl.BackGroundScrollSpeed * Time.deltaTime;
			totalDistance += distance;
			player.transform.position += new Vector3 (distance, 0);
//			if (totalDistance > gameControl.totalDistance) {
//				gameControl.GameWin ();
//			}		
		}
	}
}
