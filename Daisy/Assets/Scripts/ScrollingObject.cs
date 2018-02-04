using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
	
	public float totalDistance;
	private GameControl gameControl;

	// Use this for initialization
	void Start () 
	{
		gameControl = GameObject.FindObjectOfType<GameControl> ();
	}

	void Update()
	{
		if (!gameControl.gameOver) {
			float distance = gameControl.BackGroundScrollSpeed * Time.deltaTime;
			totalDistance += distance;
			transform.position += new Vector3 (-distance, 0);
			if (totalDistance > gameControl.totalDistance) {
				gameControl.GameWin ();
			}		
		}
	}
}
