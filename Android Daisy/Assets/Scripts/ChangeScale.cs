using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour {
	public float finalScale = 1.2f;
	public float zoomRate = 0.001f;
	
	// Update is called once per frame
	void Update () {
		float curScale = transform.localScale.z;
		if (curScale < finalScale) {
			float newScale = curScale + zoomRate;
			transform.localScale = new Vector3 (newScale, newScale, newScale);
		}
	}
}
