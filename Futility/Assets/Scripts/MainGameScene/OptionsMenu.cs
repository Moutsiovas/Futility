using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    public SceneFader sceneFader;
    public string startingScene = "StartingScene";
    public GameObject mainPanel;

    bool isOptionsMenuOpen = false;

    public void MainMenu()
    {
        sceneFader.FadeTo(startingScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnOptionsPressed()
    {
        if (!isOptionsMenuOpen)
        {
            gameObject.SetActive(true);
            isOptionsMenuOpen = true;
            mainPanel.GetComponent<CanvasGroup>().alpha = 0.75f;
            mainPanel.GetComponent<CanvasGroup>().interactable = false;
            mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnXPressed()
    {
        gameObject.SetActive(false);
        isOptionsMenuOpen = false;
        mainPanel.GetComponent<CanvasGroup>().alpha = 1f;
        mainPanel.GetComponent<CanvasGroup>().interactable = true;
        mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
