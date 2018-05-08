using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour {
	private VideoPlayer videoPlayer;
	private LevelManager levelManger;

	// Use this for initialization
	void Awake () {
		videoPlayer = GetComponent<VideoPlayer>();
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
//		print (videoPlayer.frame);
//		print (videoPlayer.frameCount);
		if (videoPlayer.frame != 0) {
			if (videoPlayer.frame == (long) videoPlayer.frameCount) {
				levelManger.LoadLevel ("LevelMenu");
			}
		}
	}
}
