using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationFunctions : MonoBehaviour {

    public SceneFader sceneFader;
    public Text topText, bottomText;
    public Image background;

    string levelToLoad = "ActPresentScene";

	void Start () {
		
	}

    public void ChangeTopText(string message)
    {
        topText.text = message;
    }

    public void ChangeBottomText(string message)
    {
        bottomText.text = message;
    }

    public void ChangeBackgroundImg()
    {
        background.GetComponent<Image>().color = Color.green;
    }

    public void NextScene()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}


