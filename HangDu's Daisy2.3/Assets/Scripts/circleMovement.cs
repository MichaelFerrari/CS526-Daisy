using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMovement : MonoBehaviour {
	public float radius = 2f;      //Distance from the center of the circle to the edge
	public float currentAngle= 0f; //Our angle, this public for debugging purposes
	private float speed = 0f;      //Rate at which we'll move around the circumference of the circle
	public float timeToCompleteCircle = 1.5f; //Time it takes to complete a full circle

	// Use this for initialization
	void Start () {

	}

	void Awake(){
		currentAngle *= (Mathf.PI / 180);
		speed = (Mathf.PI * 2) / timeToCompleteCircle;
	}

	// Update is called once per frame
	void Update () {
		speed = (Mathf.PI * 2) / timeToCompleteCircle; //For level design purposes
		currentAngle += Time.deltaTime * speed; //Changes the angle
		float newX = radius * Mathf.Cos (currentAngle);
		float newY = radius * Mathf.Sin (currentAngle);
		transform.localPosition = new Vector3 (newX, newY, transform.position.z);
		print (transform.position);
	}
}
