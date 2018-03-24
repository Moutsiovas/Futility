using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewManager : MonoBehaviour {

	public SceneFader sceneFader;
	public string levelToLoad = "ActPresentScene";
    public string outro = "OutroScene";
    public Transform scrollingPanel;
    public Text healthText;
    public GameObject characterPanelPrefab;
    public Button nextButton;
    public Image healthbar;
    public CharacterImageHandler charHandler;

    HealthPointsHandler hpHandler;
    List<int> startPoints;
    List<int> endPoints;
    List<string> people;
    Dictionary<string, string> peopleByName;
    DataServiceForPlayer dsfp;
    DataService ds;
    PlayerDB player;
    

    private void Start()
    {
        Initialize();

        healthbar = hpHandler.SetHealthBar(healthbar, player.DangerPoints);
        healthText = hpHandler.SetHealthText(healthText, player.DangerPoints);

        for(int i=0; i < endPoints.Count; i++)
        {
            int totalPoints = 0;
            if (player.ActIndex == 1)
            {
                if (endPoints[i] != 0)
                {
                    totalPoints = endPoints[i];
                }
            }
            else 
            {
                if(startPoints[i] + endPoints[i] != startPoints[i])
                {
                    totalPoints = endPoints[i];
                }
            }

            if (totalPoints != 0)
            {
                Transform temp = characterPanelPrefab.transform.Find("InfoPanel");
                temp.Find("Info").GetComponent<Text>().text = GetProperText(people[i], totalPoints);
                temp.Find("Info").GetComponent<Text>().resizeTextForBestFit = true;
                temp.Find("Text").GetComponent<Text>().text = totalPoints.ToString();
                if (totalPoints > 0)
                {
                    temp.Find("Text").GetComponent<Text>().color = Color.cyan;
                }
                else
                {
                    temp.Find("Text").GetComponent<Text>().color = Color.red;
                }

                characterPanelPrefab.transform.Find("CharacterImage").GetComponent<Image>().sprite = charHandler.SetReviewCharacterImage(peopleByName[people[i]]);

                GameObject go = Instantiate(characterPanelPrefab);
                go.transform.SetParent(scrollingPanel);
                go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

        }
        
    }

    public void Next()
	{
        if (nextButton.GetComponent<CanvasGroup>().alpha == 1)
        {
            bool isOutro = false;

            player.MomPointsAct =+ player.MomPoints;
            player.DadPointsAct =+ player.DadPoints;
            player.CousinPointsAct =+ player.CousinPoints;
            player.AuntPointsAct =+ player.AuntPoints;
            player.FriendPointsAct =+ player.FriendPoints;
            player.BossPointsAct =+ player.BossPoints;
            player.DoctorPointsAct =+ player.DoctorPoints;
            player.NailaPointsAct =+ player.NailaPoints;
            player.BrotherPointsAct =+ player.BrotherPoints;
            
            player.MomPoints = 0;
            player.DadPoints = 0;
            player.CousinPoints = 0;
            player.AuntPoints = 0;
            player.FriendPoints = 0;
            player.BossPoints = 0;
            player.DoctorPoints = 0;
            player.NailaPoints = 0;
            player.BrotherPoints = 0;

            foreach (ScenarioDB testForOutro in ds.GetSpecificScenario(player.ScenarioIndex))
            {
                if (testForOutro.TimeForOutro)
                {
                    isOutro = true;
                }
            }

            player.ScenarioIndex++;
            player.ActIndex++;
            player.CheckpointIndex = player.ScenarioIndex;

            dsfp.ReplaceData(player);


            if (isOutro)
            {
                sceneFader.FadeTo(outro);
            }
            else
            {
                sceneFader.FadeTo(levelToLoad);
            }
            
        }
	}

    void Initialize()
    {
        hpHandler = GetComponent<HealthPointsHandler>();
        player = new PlayerDB();
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
        ds = new DataService("tempDatabase.db");

        people = new List<string>();
        people.Add("Mother");
        people.Add("Father");
        people.Add("Cousin");
        people.Add("Aunt");
        people.Add("Friend");
        people.Add("Boss");
        people.Add("Doctor");
        people.Add("Psychiatrist");
        people.Add("Brother");

        peopleByName = new Dictionary<string, string>();
        peopleByName.Add("Mother" , "Vicky");
        peopleByName.Add("Father", "Hanz");
        peopleByName.Add("Cousin", "Anna");
        peopleByName.Add("Aunt", "Clay");
        peopleByName.Add("Friend", "Rory");
        peopleByName.Add("Boss", "Diamond");
        peopleByName.Add("Doctor", "Benhart");
        peopleByName.Add("Psychiatrist", "Naila");
        peopleByName.Add("Brother", "Caleb");

        
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }
        
        startPoints = new List<int>();
        endPoints = new List<int>();

        startPoints.Add(player.MomPointsAct);
        startPoints.Add(player.DadPointsAct);
        startPoints.Add(player.CousinPointsAct);
        startPoints.Add(player.AuntPointsAct);
        startPoints.Add(player.FriendPointsAct);
        startPoints.Add(player.BossPointsAct);
        startPoints.Add(player.DoctorPointsAct);
        startPoints.Add(player.NailaPointsAct);
        startPoints.Add(player.BrotherPointsAct);

        endPoints.Add(player.MomPoints);
        endPoints.Add(player.DadPoints);
        endPoints.Add(player.CousinPoints);
        endPoints.Add(player.AuntPoints);
        endPoints.Add(player.FriendPoints);
        endPoints.Add(player.BossPoints);
        endPoints.Add(player.DoctorPoints);
        endPoints.Add(player.NailaPoints);
        endPoints.Add(player.BrotherPoints);
 
    }
    
    string GetProperText(string name, int points)
    {
        string properText="";
        if(points > 0)
        {
            properText = String.Format("Your points increase by :" , name);
        }
        else {
            if (points < 0)
            {
                properText = String.Format("Your points decrease by :", name);
            }
            
        }
        return properText;
    }
}
