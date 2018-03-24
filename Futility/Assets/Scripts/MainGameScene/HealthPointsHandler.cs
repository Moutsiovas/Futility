using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsHandler : MonoBehaviour {

    public Sprite healthyBar;
    public Sprite damagedBar;
    public Sprite injuredBar;
    public Sprite criticalBar;
    
    // Use this for initialization
    void Start () {
		
	}
	
	public Image SetHealthBar(Image bar , int healthPoints)
    {
        Image returningImage = bar;
        int hp = healthPoints;

        float index = hp * (0.01f);
        returningImage.GetComponent<Image>().fillAmount = index;
        if(healthPoints >= 75)
        {
            returningImage.GetComponent<Image>().sprite = healthyBar;
        }
        else if (healthPoints >= 50)
        {
            returningImage.GetComponent<Image>().sprite = damagedBar;
        }
        else if (healthPoints >= 25)
        {
            returningImage.GetComponent<Image>().sprite = injuredBar;
        }
        else
        {
            returningImage.GetComponent<Image>().sprite = criticalBar;
        }
        return returningImage;
    }

    public Text SetHealthText(Text healthText , int healthpoints)
    {
        Text returningText = healthText;
        returningText.GetComponent<Text>().text = healthpoints.ToString();
        return returningText;
    }

    /*public Image SetNerveImage(Image leftNerve , int healthpoints)
    {
        Image returningImage = leftNerve;
        float index = (100f - healthpoints) * (0.01f);
        returningImage.GetComponent<Image>().fillAmount = index;
        return returningImage;
    }*/
}
