using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelManager : MonoBehaviour {

    public static int databaseIndex;

    public string levelToLoad = "ReviewScene";
    public string levelRepeat = "MainGameScene";

    public SceneFader scenefader;
    public AnimateDialog animateDialog;
    public Transform storyPanel;
    public Transform answersPanel, scrollingPanelForAnswers;
    public GameObject optionsMenu, answerTextPrefab, monologueBackground, tipsPanel, storyPanelArea, healthbar;
    public GameObject background , animationBackground;
    public Image mainImage, firstImage, secondImage, brainBar, leftNerveImage , rightNerveImage;
    public Button tipsButton, hideAll, optionsButton;
    public Text healthText;
    public NerveHandler rightNerve, leftNerve;

    string oldVal = "#playername#";
    string newVal;

    bool isAnswersPanelVisible = false, firstStart=true, hide = false, answerGiven = false , isTappedOnce=false;

    List<string> backgroundsName;
    List<Sprite> backgroundsSprites;

    DataService ds;
    DataServiceForAnswers dsfa;
    DataServiceForPlayer dsfp;
    ScenarioDB currentScenario;
    PlayerDB player;
    MainPanelAnimation mpAnimation;
    RelationshipGameHandler rGameHandler;
    BackgroundHandler bgHandler;
    CharacterImageHandler charHandler;
    HealthPointsHandler hpHandler;
    Sprite tempSprite;
    Coroutine co;
    Vector3 storyPosition, answerPanelPosition;

    void Start()
    {
        
        player = new PlayerDB();
        SyncDatabases();
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }
        
        databaseIndex = player.ScenarioIndex;
        newVal = player.Name;
        
        storyPosition = storyPanel.transform.localPosition;
        answerPanelPosition = answersPanel.Find("ScrollingPanel").position;
        
        if (dsfp.HasPlayerData(player,"scenarioIndex"))
        {
            databaseIndex = player.ScenarioIndex;
        }
        else
        {
           
            tipsPanel.gameObject.SetActive(true);
        }

        UpdateStoryAndAnswers();

    }

    private void Awake()
    {

        player = new PlayerDB();
        SyncDatabases();
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        //TESTING
        //    player.ScenarioIndex = 120;
        //     dsfp.ReplaceData(player);
        //TESTING

        databaseIndex = player.ScenarioIndex;
        newVal = player.Name;

        
        rGameHandler = GetComponent<RelationshipGameHandler>();
        bgHandler = GetComponent<BackgroundHandler>();
        bgHandler.SetImagesAndBackgroundsOnStart();
        charHandler = GetComponent<CharacterImageHandler>();
        charHandler.Initialize();
        mpAnimation = GetComponent<MainPanelAnimation>();
        mpAnimation.Initialize();
        hpHandler = GetComponent<HealthPointsHandler>();
        currentScenario = new ScenarioDB();
        rightNerve.Initialize();
        leftNerve.Initialize();

        storyPosition = storyPanel.transform.localPosition;
        answerPanelPosition = answersPanel.Find("ScrollingPanel").position;

        if (dsfp.HasPlayerData(player, "scenarioIndex"))
        {
            databaseIndex = player.ScenarioIndex;
        }
        else
        {

            tipsPanel.gameObject.SetActive(true);
        }
    }
    

    public void UpdateStoryAndAnswers()
    {   
        storyPanel.transform.localPosition = storyPosition;
        answersPanel.Find("ScrollingPanel").position = answerPanelPosition ;
        storyPanel.parent.GetComponent<CanvasGroup>().alpha = 0.9f;
        storyPanelArea.GetComponent<CanvasGroup>().alpha = 0.9f;
        isTappedOnce = false;
        

        IEnumerable<ScenarioDB> scenarios = ds.GetSpecificScenario(databaseIndex);
        foreach (ScenarioDB _scenario in scenarios)
        {
            currentScenario = _scenario;
            currentScenario.Question = currentScenario.Question.Replace(oldVal, newVal);

            
            co = StartCoroutine(animateDialog.AnimateStoryString(currentScenario.Question));
            /*if (animateDialog.getIsAnimationOn())
            {
                answerGiven = !answerGiven;
                animateDialog.StopAllCoroutines();
            } */      
        }

        PlayerDB player = new PlayerDB();
        foreach(PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        healthText = hpHandler.SetHealthText(healthText, player.DangerPoints);
        brainBar = hpHandler.SetHealthBar(brainBar, player.DangerPoints);

        //leftNerveImage = hpHandler.SetNerveImage(leftNerveImage, player.DangerPoints);
        //rightNerveImage = hpHandler.SetNerveImage(rightNerveImage, player.DangerPoints);

        mpAnimation.SetDangerPoints(player.DangerPoints);

       // Debug.Log(player.MomPointsAct + "<-- ACT Mom " + player.MomPoints + "<-- POINTS Mom  " + player.CousinPointsAct + "<-- ACT cousin  " + player.CousinPoints + "<-- points cousin  " + player.FriendPointsAct + "<-- Act Rory  " + player.FriendPoints + "<-- Points rory  " + player.NailaPointsAct + "<-- ACT Naila " + player.NailaPoints + "<-- POINTS Naila ");

        foreach (Transform child in answersPanel.Find("ScrollingPanel"))
        {
            Destroy(child.gameObject);
        }

        //Debug.Log(currentScenario.Id + " <-- ID  " + currentScenario.AmountOfImages + " <-- amountOfIm  " + currentScenario.MainImageName + " <-- MainImage  " + currentScenario.FirstImageName + " <-- FirstImage  " +currentScenario.SecondImageName + " <-- SecondImage  ");

        //AnswerTexts instantiation
        IEnumerable<AnswerDB> answers = dsfa.GetSpecificAnswers(databaseIndex);
        foreach (AnswerDB answer in answers)
        {
            answerTextPrefab.GetComponentInChildren<Text>().text=answer.Answer;
            GameObject go = Instantiate(answerTextPrefab);
            go.transform.SetParent(answersPanel.Find("ScrollingPanel"));
            go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Button btnScript = go.GetComponent<Button>();
            btnScript.onClick.AddListener(() => OnAnswerGiven(answers, answer, player));
            //Debug.Log("AnswerID " + answer.Id + "   kai to text tou  " + answer.Answer);
            
        }


        if (currentScenario.IsMonologue)
        {
            mainImage.gameObject.SetActive(false);
            mainImage.sprite = null;
            firstImage.gameObject.SetActive(false);
            firstImage.sprite = null;
            secondImage.gameObject.SetActive(false);
            secondImage.sprite = null;
            monologueBackground.SetActive(true);
        }
        else if (currentScenario.OnlyOneImage)
        {
            monologueBackground.SetActive(false);
            mainImage.gameObject.SetActive(true);
            firstImage.gameObject.SetActive(false);
            firstImage.sprite = null;
            secondImage.gameObject.SetActive(false);
            secondImage.sprite = null;

        } else {
            monologueBackground.SetActive(false);
            mainImage.gameObject.SetActive(false);
            mainImage.sprite = null;
            firstImage.gameObject.SetActive(true);
            secondImage.gameObject.SetActive(true);
        }

        if (!currentScenario.IsMonologue)
        {

            List<Sprite> tempList = charHandler.SetBackground(currentScenario);
            //Debug.Log("EdwFtanwMexriToError");
            if (currentScenario.AmountOfImages == 1)
            {
                mainImage.GetComponent<Image>().sprite = tempList[0];
            }
            else
            {
                firstImage.GetComponent<Image>().sprite = tempList[0];

                secondImage.GetComponent<Image>().sprite = tempList[1];
            }
        }

        tempSprite = bgHandler.SetBackground(currentScenario);
        background.GetComponent<Image>().sprite = tempSprite;
      
        IEnumerable<ScenarioDB> specScenario = ds.GetSpecificScenario(databaseIndex - 1);
        foreach (ScenarioDB scen in specScenario)
        {
            if (scen.BackgroundName != currentScenario.BackgroundName)
            {
                animationBackground.SetActive(true);
            }
        }

    }

    public void OnAnswerGiven(IEnumerable<AnswerDB> answers, AnswerDB _answerDB, PlayerDB player)
    {
        PlayerDB tempPlayer = new PlayerDB();
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            tempPlayer = _player;
        }


        //TESTING
        Debug.Log("RelationshipType :" + _answerDB.RelationshipT + "Relationship points: " + _answerDB.RelationshipPoints);
        //TESTING

        // Check for dangerPoints
        if (tempPlayer.DangerPoints + _answerDB.DangerPoints <= 100)
        {
            tempPlayer.DangerPoints += _answerDB.DangerPoints;
            if (tempPlayer.DangerPoints <= 0)
            {

                tempPlayer.ScenarioIndex = tempPlayer.CheckpointIndex;
                tempPlayer.DangerPoints = 50;
                tempPlayer.MomPoints = tempPlayer.MomPointsAct;
                tempPlayer.DadPoints = tempPlayer.DadPointsAct;
                tempPlayer.CousinPoints = tempPlayer.CousinPointsAct;
                tempPlayer.AuntPoints = tempPlayer.AuntPointsAct;
                tempPlayer.FriendPoints = tempPlayer.FriendPointsAct;
                tempPlayer.BossPoints = tempPlayer.BossPointsAct;
                tempPlayer.DoctorPoints = tempPlayer.DoctorPointsAct;
                tempPlayer.NailaPoints = tempPlayer.NailaPointsAct;

                dsfp.ReplaceData(tempPlayer);

                scenefader.FadeTo(levelRepeat);
                return;
            }
        }
        // Check for dangerPoints


        healthText = hpHandler.SetHealthText(healthText, tempPlayer.DangerPoints);
        brainBar = hpHandler.SetHealthBar(brainBar, tempPlayer.DangerPoints);
        leftNerve.SetHealthPoints(tempPlayer.DangerPoints);
        rightNerve.SetHealthPoints(tempPlayer.DangerPoints);

        //leftNerveImage = hpHandler.SetNerveImage(leftNerveImage, player.DangerPoints);
        //rightNerveImage = hpHandler.SetNerveImage(rightNerveImage, player.DangerPoints);

        AnswerDB answer = _answerDB;
        tempPlayer = rGameHandler.SetRelationshipPoints(tempPlayer, answer);
      
        if (currentScenario.IsItTheLast)
        {
            scenefader.FadeTo(levelToLoad);
            return;
        }

        databaseIndex = ChooseNextScenarioIndex(answer);
        tempPlayer.ScenarioIndex = databaseIndex; 
        answersPanel.gameObject.SetActive(false);

        dsfp.ReplaceData(tempPlayer);
        PlayerDB pTest = new PlayerDB();
        foreach (PlayerDB test in dsfp.GetPlayerData())
        {
            pTest = test;
        }
        Debug.Log("MOM:" + pTest.MomPoints + "AUNT:" + pTest.AuntPoints + "Cousin:" + pTest.CousinPoints);
        UpdateStoryAndAnswers();
        isAnswersPanelVisible = false;
    }

    public void OnSimpleTap()
	{
        if (animateDialog.getIsAnimationOn() && !isTappedOnce)
        {
            StopCoroutine(co);
            storyPanel.GetComponent<Text>().text = currentScenario.Question;
            isTappedOnce = true;
            return;
        }
       
        if (currentScenario.IsItTheLast)
        {
            scenefader.FadeTo(levelToLoad);
            return;
        }

        int childCount = 0;
        foreach (Transform child in answersPanel.Find("ScrollingPanel"))
        {
            childCount++;
        }

        if (childCount == 1)
        {
            Continue();
            return;
        }

        if (!isAnswersPanelVisible) {
			answersPanel.gameObject.SetActive (true);
			isAnswersPanelVisible = true;
            storyPanel.parent.GetComponent<CanvasGroup>().alpha = 0.7f;
            storyPanelArea.GetComponent<CanvasGroup>().alpha = 0.7f;
		} 
		else 
		{
			answersPanel.gameObject.SetActive (false);
			isAnswersPanelVisible = false;
            storyPanel.parent.GetComponent<CanvasGroup>().alpha = 0.9f;
            storyPanelArea.GetComponent<CanvasGroup>().alpha = 0.9f;
        }
	}

    void SyncDatabases()
    {
        ds = new DataService("tempDatabase.db");
        dsfa = new DataServiceForAnswers("tempDatabaseForAnswers.db");
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");

        //ds.CreateDB();
        //dsfa.CreateDB();
        
    }

    int ChooseNextScenarioIndex(AnswerDB answer)
    {
        int index = databaseIndex;
        if (answer.PointingScenarioIndex == 0)
        {
            index++;
            return index;
        }
        else
        {
            index = answer.PointingScenarioIndex;
            return index;
        }
    }

    public void Next()
    {
        scenefader.FadeTo(levelToLoad);
    }

    public void TipsStart()
    {
        tipsPanel.gameObject.SetActive(false);
    }

    private void Continue()
    {
        PlayerDB tempPlayer = new PlayerDB();
        AnswerDB tempAnswer = new AnswerDB();
        foreach (PlayerDB player in dsfp.GetPlayerData())
        {
            tempPlayer = player;
        }

        foreach (AnswerDB answer in dsfa.GetSpecificAnswers(databaseIndex))
        {
            tempAnswer = answer;
        }

        databaseIndex = ChooseNextScenarioIndex(tempAnswer);
        tempPlayer.ScenarioIndex = databaseIndex;

        dsfp.ReplaceData(tempPlayer);
        UpdateStoryAndAnswers();
    }
    
    public bool getAnswerGiven()
    {
        return answerGiven;
    }
    
    public void setAnswerGiven(bool _answerGiven)
    {
        answerGiven = _answerGiven;
    }

    public Sprite getBgSprite()
    {
        return tempSprite;
    }
}
