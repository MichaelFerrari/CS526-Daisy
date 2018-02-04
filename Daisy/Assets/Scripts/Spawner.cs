using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject prefabObject;
	public float spawnRate = 30f;

	private ScrollingObject scrolling;
	private float distanceSum;
	// Use this for initialization
	void Start () {
		scrolling = GameObject.FindObjectOfType<ScrollingObject> ();
		distanceSum = spawnRate;

		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (prefabObject, child.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	// Update is called once per frame
	void Update () {
		float currentDistance = scrolling.totalDistance;
		if (currentDistance > distanceSum) {
			distanceSum += spawnRate;
			foreach (Transform child in transform) {
				if (child.transform.childCount == 0) {
					GameObject enemy = Instantiate (prefabObject, child.position, Quaternion.identity);
					enemy.transform.parent = child;
				}
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3(16f, 12f));
	}
}
