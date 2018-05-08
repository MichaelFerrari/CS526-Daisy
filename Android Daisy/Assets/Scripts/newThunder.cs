using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newThunder : MonoBehaviour {
	private float totalTime;
	private bool isShow;
	private SpriteRenderer spriteR;
	private PolygonCollider2D polygonCollider;

	public float blinkPeriod;

	// Use this for initialization
	void Start () {
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
		totalTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if (totalTime > blinkPeriod) {
			totalTime = 0;
			isShow = !isShow;
		}

		if (isShow) {
			spriteR.enabled = true;
			polygonCollider.enabled = true;
		} else {
			spriteR.enabled = false;
			polygonCollider.enabled = false;
		}
	}
}
