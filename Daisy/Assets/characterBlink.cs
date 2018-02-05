using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterBlink : MonoBehaviour {
	Renderer render;
	private void Start()
	{
		render = GetComponent<Renderer>();
	}
	public void startblinking()
	{
		StartCoroutine(DoBlinks(0.5f, 0.1f));
	}

	IEnumerator DoBlinks(float duration, float blinkTime)
	{
		while (duration > 0f)
	{
		duration -= Time.deltaTime;
//toggle renderer
		render.enabled = !render.enabled ;
//renderer.enabled = !renderer.enabled;

//wait for a bit
		yield return new WaitForSeconds(blinkTime);
	}

//make sure renderer is enabled when we exit
	render.enabled = true;
	}
}