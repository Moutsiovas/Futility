using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActPresentManager : MonoBehaviour {

    public SceneFader sceneFader;
	public Text actText , titleText;

    string levelToLoad;
    DataServiceForPlayer dsfp;
    PlayerDB player = new PlayerDB();

	void Start () {
        SyncDatabase();
        levelToLoad = "MainGameScene";

        foreach(PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

		switch(player.ActIndex)
		{	
		case 1:
                actText.text = "ACT I";
                titleText.text = "DECISIONS";
			break;
		case 2:
                actText.text = "ACT II";
                titleText.text = "RESEARCHING";
			break;
		case 3:
                actText.text = "ACT III";
                titleText.text = "ANALYZING";
			break;
		case 4:
                actText.text = "ACT IV";
                titleText.text = "DISCOVERING";
			break;
		case 5:
                actText.text = "ACT V";
                titleText.text = "FUTILITY";
			break;
		}
	}
	
    void SyncDatabase()
    {
       dsfp  = new DataServiceForPlayer("tempDatabaseForPlayer.db");
    }

    public void NextScene()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
