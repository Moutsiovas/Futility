using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterNameManager : MonoBehaviour {
    
    public string levelToLoad="PrologueScene";
	public InputField nameInputField;
	public SceneFader sceneFader;
    public GameObject warningPanel;

    DataServiceForPlayer dsfp;

    private void Start()
    {
        SyncDatabase();
    }

    public void Begin()
	{
		string name = nameInputField.text;
        

        if(name.Length > 8)
        {
            StartCoroutine(WarningPanel());
            return;
        }

		if(name != "")
		{
            foreach (PlayerDB player in dsfp.GetPlayerData())
            {
                player.Name = name;
                dsfp.ReplaceData(player);
                
                break;
            }
			sceneFader.FadeTo (levelToLoad);
		}

        
	}

    IEnumerator WarningPanel()
    {
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        warningPanel.SetActive(false);
    }
    void SyncDatabase()
    {
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
    }
}