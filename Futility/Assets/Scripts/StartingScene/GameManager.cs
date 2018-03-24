using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public string levelToLoadForNew= "EnterNameScene";
    public string levelToLoadForContinue = "MainGameScene";
    public string levelToLoadForAboutUs = "AboutUsScene";
    public Text text1, text2, text3, text4;

    DataServiceForPlayer dsfp;
    DataService ds;

    public SceneFader sceneFader;
    public GameObject reminderPanel;
    public Text continueText;

   private void Start()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        SyncDatabases();
        
        PlayerDB _player = new PlayerDB();
        foreach(PlayerDB player in dsfp.GetPlayerData())
        {
            _player = player;
        }

        if (!dsfp.HasPlayerPlayed(_player))
        {
            continueText.GetComponent<Text>().color = Color.gray;
            continueText.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            continueText.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void NewGame()
	{
        PlayerDB player = new PlayerDB();
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        if (dsfp.HasPlayerPlayed(player))
        {
            reminderPanel.SetActive(true);
            reminderPanel.transform.Find("TextPanel").Find("Text").GetComponent<Text>().text = "You already have a saved file. Do you wish to create a new one?";
            reminderPanel.transform.Find("ButtonsPanel").gameObject.SetActive(true);
            return;
        }

        dsfp.CreateDB();
		sceneFader.FadeTo (levelToLoadForNew);
	}

    public void Continue()
    {
        PlayerDB tempPlayer = new PlayerDB();
        foreach(PlayerDB _player in dsfp.GetPlayerData())
        {
            tempPlayer = _player;
        }

        if (dsfp.HasPlayerData(tempPlayer, "scenarioIndex"))
        {
            sceneFader.FadeTo(levelToLoadForContinue);
        }
        else
        {
            reminderPanel.transform.Find("TextPanel").Find("Text").GetComponent<Text>().text = "You don't have a saved file. Start a new game now.";
            reminderPanel.SetActive(true);
            reminderPanel.transform.Find("ButtonsPanel").gameObject.SetActive(false);

            float time = 2;
            StartCoroutine(PopUp(time, reminderPanel));
            return;
        }  
    }

    public void AboutUs()
    {
        sceneFader.FadeTo(levelToLoadForAboutUs);
    }
    
    public void Proceed()
    {
        dsfp.CreateDB();
        reminderPanel.SetActive(false);
        sceneFader.FadeTo(levelToLoadForNew);
    }

    public void No()
    {
        reminderPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator PopUp(float time, GameObject toFade)
    {
        yield return new WaitForSeconds(time);
        toFade.SetActive(false);
    }

    void SyncDatabases()
    {
        ds = new DataService("tempDatabase.db");
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
    }
}
