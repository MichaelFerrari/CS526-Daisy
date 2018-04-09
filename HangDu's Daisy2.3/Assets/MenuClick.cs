﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuClick : MonoBehaviour {

	private Vector3 initialScale;

	void Awake()
	{
		LevelMenu2D.I.OnItemClicked += OnItemClicked;
		if (LevelManager.prevLevel == "Level_01_Win") {
			LevelMenu2D.I.initialItemNumber = 0;
		} else if (LevelManager.prevLevel == "Level_02_Win") {
			LevelMenu2D.I.initialItemNumber = 1;
		} else if (LevelManager.prevLevel == "Level_03_Win") {
			LevelMenu2D.I.initialItemNumber = 2;
		} else if (LevelManager.prevLevel == "Level_04_Win") {
			LevelMenu2D.I.initialItemNumber = 3;
		} else if (LevelManager.prevLevel == "Level_05_Win") {
			LevelMenu2D.I.initialItemNumber = 4;
		}
	}

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
		print (LevelManager.prevLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnItemClicked (int itemIndex, GameObject itemObject)
	{


//		//Debug.Log("Item Clicked");
//		initialScale = itemObject.transform.localScale;
//		//iTween.ScaleBy(itemObject, new Vector3(2f, 2f, 0f), 0.5f);
//		if (itemIndex >= 0 && itemIndex <= 2)
//		{
//			iTween.ScaleBy(itemObject, iTween.Hash("x", 1.5f, "y", 1.5f, "time", 0.5f, "looptype", "none", "easetype", "easeInOutBack"));
//			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.5f, "easetype", "easeOutBack", "looptype", "none", "delay", 0.5f));
//		} else if (itemIndex >= 3 && itemIndex <= 5)
//		{
//			iTween.ScaleTo(itemObject, iTween.Hash("x", 1.4f, "y", 1.4f, "time", 0.1f, "looptype", "none"));
//			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.1f, "delay", 0.1f, "looptype", "none"));
//		}

//		if (itemIndex % 2 == 0) {
//			
//		} else if (itemIndex % 2 == 1) {
//			SceneManager.LoadScene("Level_02", LoadSceneMode.Single);
//		}

		Debug.Log("Item Clicked: " + itemIndex + " Name: " + itemObject.name);
		SceneManager.LoadScene(itemObject.name, LoadSceneMode.Single);

	}
}