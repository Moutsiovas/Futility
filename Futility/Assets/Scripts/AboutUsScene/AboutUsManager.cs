using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutUsManager : MonoBehaviour {

    public SceneFader scenefader;
    public string levelToLoad = "StartingScene";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
        scenefader.FadeTo(levelToLoad);
    }
}
