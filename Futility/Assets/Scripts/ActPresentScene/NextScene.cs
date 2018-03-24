using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

	public string levelToLoad = "MainGameScene";
	public SceneFader sceneFader;

	void Start()
	{
		GoToNextScene ();
	}

	public void GoToNextScene()
	{
		sceneFader.FadeTo (levelToLoad);
	}
}
