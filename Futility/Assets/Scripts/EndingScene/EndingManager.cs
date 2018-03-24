using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour {

    public SceneFader scenefader;
    public GameObject reviewPanelPref, scrollingPanel;
    public int momPointsTotal, dadPointsTotal, cousinPointsTotal, auntPointsTotal, friendPointsTotal, bossPointsTotal, doctorPointsTotal, nailaPointsTotal;

    List<string> people;
    List<int> pointsSoFar;
    string levelToLoad = "StartingScene";
    DataServiceForPlayer dsfp;

	// Use this for initialization
	void Start () {
        PlayerDB player = new PlayerDB();
        SyncDatabase();

        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        InstantiateObjects(player);

       

        for(int i=0;i < people.Count; i++)
        {
            reviewPanelPref.transform.Find("Text").GetComponent<Text>().text = String.Format("Your points with {0} are :", people[i]);
            reviewPanelPref.transform.Find("Points").GetComponent<Text>().text = String.Format("{0} / 100", pointsSoFar[i].ToString());
            

            GameObject go = Instantiate(reviewPanelPref);
            SetPanelColor(go, i);
            go.transform.SetParent(scrollingPanel.transform);
            go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
	}
    
    public void MainMenu()
    {
        scenefader.FadeTo(levelToLoad);
    }

    void InstantiateObjects(PlayerDB player)
    {
        people.Add("Mom");
        people.Add("Dad");
        people.Add("Cousin");
        people.Add("Aunt");
        people.Add("Friend");
        people.Add("Boss");
        people.Add("Doctor");
        people.Add("Naila");

        pointsSoFar.Add(player.MomPoints);
        pointsSoFar.Add(player.DadPoints);
        pointsSoFar.Add(player.CousinPoints);
        pointsSoFar.Add(player.AuntPoints);
        pointsSoFar.Add(player.FriendPoints);
        pointsSoFar.Add(player.BossPoints);
        pointsSoFar.Add(player.DoctorPoints);
        pointsSoFar.Add(player.NailaPoints);
    }

    void SetPanelColor(GameObject go, int i)
    {
        int tempTotal=0;
        switch (i)
        {
            case 0:
                tempTotal = momPointsTotal;
                break;

            case 1:
                tempTotal = dadPointsTotal;
                break;
            case 2:
                tempTotal = cousinPointsTotal;
                break;
            case 3:
                tempTotal = auntPointsTotal;
                break;
            case 4:
                tempTotal = friendPointsTotal;
                break;
            case 5:
                tempTotal = bossPointsTotal;
                break;
            case 6:
                tempTotal = doctorPointsTotal;
                break;
            case 7:
                tempTotal = nailaPointsTotal;
                break;
        }

        if(pointsSoFar[i] > (tempTotal / 2.0))
        {
            go.transform.GetComponent<Image>().color = Color.yellow;
        }

        if (pointsSoFar[i] > (tempTotal / 1.5))
        {
            go.transform.GetComponent<Image>().color = Color.green;
        }

        if (pointsSoFar[i] < (tempTotal /3.5))
        {
            go.transform.GetComponent<Image>().color = Color.grey;
        }
    }

    void SyncDatabase()
    {
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
        pointsSoFar = new List<int>();
        people = new List<string>();
    }
}
