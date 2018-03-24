using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingToolManager : MonoBehaviour {

    [Header("Scenario")]
    public InputField questionIf, idIf, amountOfImagesIf, backgroundNameIf, mainImageIf, firstImageIf, secondaryIf;
    [Header("Scenario")]
    public Toggle isMonologueTgl, isItLastTgl, timeForOutroTgl, onlyOneImageTgl;
    [Header("Answer")]
    public InputField answerIf, answerIdIf, dangerPointsIf, relationshipPointsIf, scenarioIndexIf, pointingScenarioIndexIf;
    [Header("PointScen")]
    public InputField idPointIf, pointScenarioIf , pointScIndexIf;
    public Text lastPointScen;
    [Header("Continue")]
    public InputField idContinueIf, scenarioIndexContinueIf, pointingScenIndex;
    public Text lastID;
    [Header("Toggles")]
    public Toggle noneTog,momTog, dadTog, cousinTog, auntTog, friendTog, bossTog, doctorTog, nailaTog, brotherTog;

    public GameObject relationshipTypePanel;

    DataService ds = new DataService("tempDatabase.db");
    DataServiceForAnswers dsfa = new DataServiceForAnswers("tempDatabaseForAnswers.db");
    DataServiceForPlayer dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");

    string nameMacro = "#playername#";
    string tempNameMacro = "Bodakos";

    void Start() {
        
        
        IEnumerable<ScenarioDB> scenarios = ds.GetScenarios();
        
        foreach (ScenarioDB scenario in scenarios)
        {
            if(scenario.MainImageName == "Gregory")
            {
                Debug.Log(scenario.Id);
            }
        }

         /*foreach (AnswerDB answer in dsfa.GetAnswers())
         {
           if(answer.Id >= 255)
           {
                Debug.Log(answer.Answer + "\n" + answer.ScenarioIndex + "     " + answer.PointingScenarioIndex + "  ID :" + answer.Id + "     " + answer.RelationshipT + "danger points" + answer.DangerPoints);

           }
         } 
        */
        SetAnswerInfoTexts();
    }

    public void SetAnswerInfoTexts()
    {
        int temp = 2;
        AnswerDB answerToShow = new AnswerDB();
        foreach (AnswerDB answer in dsfa.GetAnswers())
        {            
            if(answer.Id > temp)
            {
                answerToShow = answer;
                temp = answer.Id;
            }
            
        }

        lastID.GetComponent<Text>().text = answerToShow.Id.ToString();

        int tempScen = 1;
        AnswerDB answerToShowScen = new AnswerDB();
        foreach (AnswerDB _answer in dsfa.GetAnswers())
        {
            if (_answer.ScenarioIndex > tempScen)
            {
                answerToShowScen = _answer;
                tempScen = _answer.ScenarioIndex;
            }
           
        }

        lastPointScen.GetComponent<Text>().text = answerToShowScen.ScenarioIndex.ToString();

    }

    public void OnEnterPress()
    {
        if (questionIf.GetComponent<InputField>().text == "" || idIf.GetComponent<InputField>().text == "" || amountOfImagesIf.GetComponent<InputField>().text == "" || backgroundNameIf.GetComponent<InputField>().text == "" || mainImageIf.GetComponent<InputField>().text == "" || firstImageIf.GetComponent<InputField>().text == "" || secondaryIf.GetComponent<InputField>().text == "")
        {
            Debug.LogError("Simplirwse ta panta");
            return;
        }

        ScenarioDB currentScenario = new ScenarioDB();

        currentScenario.Question = questionIf.GetComponent<InputField>().text;
        currentScenario.BackgroundName = backgroundNameIf.GetComponent<InputField>().text;
        currentScenario.MainImageName = mainImageIf.GetComponent<InputField>().text;
        currentScenario.FirstImageName = firstImageIf.GetComponent<InputField>().text;
        currentScenario.SecondImageName = secondaryIf.GetComponent<InputField>().text;

        int j;
        if (Int32.TryParse(idIf.GetComponent<InputField>().text, out j))
            currentScenario.Id = j;
        else
            Console.WriteLine("String could not be parsed.");

        if (Int32.TryParse(amountOfImagesIf.GetComponent<InputField>().text, out j))
            currentScenario.AmountOfImages = j;
        else
            Console.WriteLine("String could not be parsed.");
        

        if (isMonologueTgl.GetComponent<Toggle>().isOn)
            currentScenario.IsMonologue = true;
        else
            currentScenario.IsMonologue = false;

        if (isItLastTgl.GetComponent<Toggle>().isOn)
            currentScenario.IsItTheLast = true;
        else
            currentScenario.IsItTheLast = false;

        if (timeForOutroTgl.GetComponent<Toggle>().isOn)
            currentScenario.TimeForOutro = true;
        else
            currentScenario.TimeForOutro = false;

        if (onlyOneImageTgl.GetComponent<Toggle>().isOn)
            currentScenario.OnlyOneImage = true;
        else
            currentScenario.OnlyOneImage = false;
       

        ds.InsertOrReplaceScenario(currentScenario);
        ResetInputFieldsOnScenarioPanel();
        
    }
    
    void ResetInputFieldsOnScenarioPanel()
    {
        questionIf.GetComponent<InputField>().text = "";
        int temp = 0;
        int.TryParse(idIf.GetComponent<InputField>().text, out temp);
        idIf.GetComponent<InputField>().text = (temp + 1).ToString();


    }

    public void OnAnswerEnterPress()
    {
        if (answerIf.GetComponent<InputField>().text == "" || answerIdIf.GetComponent<InputField>().text == "" || dangerPointsIf.GetComponent<InputField>().text == "" || scenarioIndexIf.GetComponent<InputField>().text == "" || pointingScenarioIndexIf.GetComponent<InputField>().text == "")
        {
            Debug.LogError("Simplirwse ta panta");
            return;
        }

        AnswerDB currentAnswer = new AnswerDB();

        currentAnswer.Answer = answerIf.GetComponent<InputField>().text;
        foreach(Transform toggle in relationshipTypePanel.transform)
        {
            if (toggle.GetComponent<Toggle>().isOn)
            {
                switch (toggle.name)
                {
                    case "NoneTog":
                        currentAnswer.RelationshipT = RelationshipType.NONE;
                        break;
                    case "MomTog":
                       currentAnswer.RelationshipT = RelationshipType.MOM;
                       break;
                    case "DadTog":
                        currentAnswer.RelationshipT = RelationshipType.DAD;
                        break;
                    case "AuntTog":
                        currentAnswer.RelationshipT = RelationshipType.AUNT;
                        break;
                    case "CousinTog":
                        currentAnswer.RelationshipT = RelationshipType.COUSIN;
                        break;
                    case "FriendTog":
                        currentAnswer.RelationshipT = RelationshipType.FRIEND;
                        break;
                    case "BossTog":
                        currentAnswer.RelationshipT = RelationshipType.BOSS;
                        break;
                    case "DoctorTog":
                        currentAnswer.RelationshipT = RelationshipType.DOCTOR;
                        break;
                    case "NailaTog":
                        currentAnswer.RelationshipT = RelationshipType.NAILA;
                        break;
                    case "BrotherTog":
                        currentAnswer.RelationshipT = RelationshipType.BROTHER;
                        break;
                }
            }
        }

        int j;
        if (Int32.TryParse(answerIdIf.GetComponent<InputField>().text, out j))
            currentAnswer.Id = j;
        else
            Console.WriteLine("String could not be parsed.");

        if (Int32.TryParse(dangerPointsIf.GetComponent<InputField>().text, out j))
            currentAnswer.DangerPoints = j;
        else
            Console.WriteLine("String could not be parsed.");
        
        if (Int32.TryParse(relationshipPointsIf.GetComponent<InputField>().text, out j))
            currentAnswer.RelationshipPoints = j;
        else
            Console.WriteLine("String could not be parsed.");

        if (Int32.TryParse(scenarioIndexIf.GetComponent<InputField>().text, out j))
            currentAnswer.ScenarioIndex = j;
        else
            Console.WriteLine("String could not be parsed.");

        if (Int32.TryParse(pointingScenarioIndexIf.GetComponent<InputField>().text, out j))
            currentAnswer.PointingScenarioIndex = j;
        else
            Console.WriteLine("String could not be parsed.");

        dsfa.InsertOrReplaceAnswer(currentAnswer);
        ResetAnswerPanel();
       }

    public void ResetAnswerPanel()
    {
        answerIf.GetComponent<InputField>().text = "";
       
        dangerPointsIf.GetComponent<InputField>().text = "";
        relationshipPointsIf.GetComponent<InputField>().text = "";
        
    }

    public void OnPointScenarioEnter()
    {
        int id = 0 , pointingScen = 0 , scenarioIndex = 0;
        int.TryParse(idPointIf.GetComponent<InputField>().text , out id);
        int.TryParse(pointScenarioIf.GetComponent<InputField>().text, out pointingScen);
        int.TryParse(pointScIndexIf.GetComponent<InputField>().text, out scenarioIndex);


        foreach (AnswerDB answer in dsfa.GetSpecificAnswersByID(id))
        {
            answer.PointingScenarioIndex = pointingScen;
            answer.ScenarioIndex = scenarioIndex;
            dsfa.InsertOrReplaceAnswer(answer);
        }
        idPointIf.GetComponent<InputField>().text = "";

        
    }

    public void OnContinueEnter()
    {
        int id = 0, scenarioIndex = 0, _pointingScenIndex = 0 ;
        int.TryParse(idContinueIf.GetComponent<InputField>().text, out id);
        int.TryParse(scenarioIndexContinueIf.GetComponent<InputField>().text, out scenarioIndex);
        int.TryParse(pointingScenIndex.GetComponent<InputField>().text, out _pointingScenIndex);

        dsfa.CreateContinueAnswer(id, scenarioIndex , _pointingScenIndex);

        idContinueIf.GetComponent<InputField>().text =(id + 1).ToString();
        scenarioIndexContinueIf.GetComponent<InputField>().text = (scenarioIndex+1).ToString();

        
    }


}
