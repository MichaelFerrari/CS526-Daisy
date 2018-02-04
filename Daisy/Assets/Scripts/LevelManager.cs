using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name) {
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void ExitRequest() {
		Debug.Log("I want to exit!");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

//	public void BrickDestroyed() {
//		if (Bricks.brickCount <= 0) {
//			LoadNextLevel ();
//		}
//	}
}
