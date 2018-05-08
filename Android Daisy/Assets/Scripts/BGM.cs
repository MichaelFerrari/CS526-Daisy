using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
	
	static BGM instance = null;
	AudioSource _audioSource;
	static int counter = 0;
	// Use this for initialization
//	void Awake() {
//		Debug.Log ("Music player Awake " + GetInstanceID());
//		if (instance == null) {
//			instance = this;
//			GameObject.DontDestroyOnLoad (gameObject);
//		} else {
//			Destroy (gameObject);
//			print ("Duplicate music player self-destructing");
//		}
//	}
	void Awake() {
//		if (instance == null) {
//			instance = this;
//			GameObject.DontDestroyOnLoad (gameObject);
//		} else {
//			Destroy (gameObject);
//			print ("Duplicate music player self-destructing");
//		}

		Debug.Log ("Now is calling Awake Function " + counter++);
		_audioSource = GetComponent<AudioSource>();
		if (!_audioSource.isPlaying)
			_audioSource.Play();
	}


	void Start () {
		Debug.Log ("Music player Start " + GetInstanceID());
		Debug.Log ("Now is calling Start Function " + counter++);
//		if(mute.isMuting)
//		{
//			Destroy (gameObject);
//		}
//		_audioSource = GetComponent<AudioSource>();
//		_audioSource.playOnAwake();
		if (!_audioSource.isPlaying)
			_audioSource.Play();
	}


	public void toMenu()
	{
//		Destroy (gameObject);
		pauseMenu.GameIsPaused = false;
		Debug.Log ("To Menu " + GetInstanceID());
		if (!_audioSource.isPlaying && !mute.isMuting)
			_audioSource.Play();

	}
	
	// Update is called once per frame
	void Update () {
		

		if (!_audioSource.isPlaying && ! (pauseMenu.GameIsPaused  || mute.isMuting ) ) {
			_audioSource.Play ();
		}

		if(pauseMenu.GameIsPaused)
		{
			_audioSource.Pause();
		}

		if(mute.isMuting)
		{
			_audioSource.Pause();
		}
			
	}
}
