using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fadeAndLoad : MonoBehaviour {
	
	private LevelManager levelManger;
	public float time;

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			GetComponent<Animation>().Play("FadeOut");
			levelManger.LoadLevel ("LevelMenu");
		}
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(time);
		GetComponent<Animation>().Play ("FadeOut");
		levelManger.LoadLevel ("LevelMenu");

	}
}
