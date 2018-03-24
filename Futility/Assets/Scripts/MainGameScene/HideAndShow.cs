using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAndShow : MonoBehaviour {

    public Sprite visible, notVisible;
    public GameObject storyPanelArea, answersPanel, optionsButton, healthbar;

    private bool hide;
	// Use this for initialization
	void Start () {
        hide = true;
	}
	
    public void HideAll()
    {
        if (hide)
        {
            storyPanelArea.GetComponent<CanvasGroup>().alpha = 0f;
            answersPanel.GetComponent<CanvasGroup>().alpha = 0f;
            optionsButton.GetComponent<CanvasGroup>().alpha = 0f;
            healthbar.GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<Image>().sprite = notVisible;

            hide = !hide;
        }
        else
        {
            storyPanelArea.GetComponent<CanvasGroup>().alpha = 0.9f;
            answersPanel.GetComponent<CanvasGroup>().alpha = 0.9f;
            optionsButton.GetComponent<CanvasGroup>().alpha = 0.9f;
            healthbar.GetComponent<CanvasGroup>().alpha = 0.9f;
            GetComponent<Image>().sprite = visible;

            hide = !hide;
        }
    }
}
