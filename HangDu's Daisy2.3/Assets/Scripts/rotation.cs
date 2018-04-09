using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	public float rotateSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.z += rotateSpeed;
		transform.rotation = Quaternion.Euler(rotationVector);
	}
}
