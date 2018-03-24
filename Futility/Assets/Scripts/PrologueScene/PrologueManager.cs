using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrologueManager : MonoBehaviour
{

    public SceneFader sceneFader;
    public string levelToLoad = "ActPresentScene";
    public Text topText;

    DataServiceForPlayer dsfp;


    private void Start()
    {
        SyncDatabase();
        PlayerDB player = new PlayerDB();
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        topText.text = String.Format("Hello, my name is {0} and I have schizophrenia.", player.Name);
    }

    void SyncDatabase()
    {
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
    }

    public void Skip()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
  