using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static string prevLevel;

	public void LoadLevel(string name) {
		setPrevLevel ();
		SceneManager.LoadScene(name, LoadSceneMode.Single);
        Time.timeScale = 1f;
	}

	public void ExitRequest() {
		Debug.Log("I want to exit!");
		Application.Quit();
	}

	public void LoadNextLevel() {
		setPrevLevel ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void setPrevLevel() {
		prevLevel = SceneManager.GetActiveScene ().name;
	}

//	void Update() {
//		print (SceneManager.GetActiveScene ().name);
//	}

//	public void BrickDestroyed() {
//		if (Bricks.brickCount <= 0) {
//			LoadNextLevel ();
//		}
//	}
}
