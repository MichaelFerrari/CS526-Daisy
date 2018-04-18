using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour {
    public GameObject mute_btn;
    public GameObject unmute_btn;
    public static bool isMuting = false;

    public void Awake()
    {
    	if(isMuting)
    	{
			mute_btn.SetActive(false);
        	unmute_btn.SetActive(true);
    	}

    }


    public void mutegaming () {
        Debug.Log("test");
        mute_btn.SetActive(false);
        unmute_btn.SetActive(true);
        isMuting = true;
    }
	

	public void unmutegaming () {
        Debug.Log("test");
        mute_btn.SetActive(true);
        unmute_btn.SetActive(false);
		isMuting = false;
    }
}
