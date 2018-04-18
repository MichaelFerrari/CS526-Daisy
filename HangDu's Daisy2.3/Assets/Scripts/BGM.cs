using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
	
	static BGM instance = null;
	// Use this for initialization
	void Awake() {
		Debug.Log ("Music player Awake " + GetInstanceID());
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing");
		}
	}

	void Start () {
		Debug.Log ("Music player Start " + GetInstanceID());
		if(mute.isMuting)
		{
			Destroy (gameObject);
		}
	}


	public void toMenu()
	{
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
