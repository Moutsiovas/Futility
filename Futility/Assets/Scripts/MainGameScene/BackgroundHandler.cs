using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour {

    public Sprite background1, background2, background3, background4, background5, background6, background7, background8, background9, background10, background11, background12, background13;

    List<string> backgroundsName;
    List<Sprite> backgroundsSprites;

    // Use this for initialization
    void Start () {
        //SetImagesAndBackgroundsOnStart();	
	}

    public Sprite SetBackground(ScenarioDB scenario)
    {
        Sprite returnignSprite = new Sprite();
        for (int i = 0; i < backgroundsName.Count; i++)
        { 
            if (scenario.BackgroundName == backgroundsName[i])
            {
                returnignSprite = backgroundsSprites[i];
                return returnignSprite;
            }
        }

        return returnignSprite;
    }

    public void SetImagesAndBackgroundsOnStart()
    {
        backgroundsName = new List<string>();
        backgroundsSprites = new List<Sprite>();

        backgroundsName.Clear();
        backgroundsSprites.Clear();

        backgroundsName.Add("Bar");
        backgroundsName.Add("Cafeteria");
        backgroundsName.Add("Clinic");
        backgroundsName.Add("Graveyard");
        backgroundsName.Add("Graveyard(Night)");
        backgroundsName.Add("Hospital(Day)");
        backgroundsName.Add("Hospital(Night");
        backgroundsName.Add("Journalism");
        backgroundsName.Add("Kitchen(Day)");
        backgroundsName.Add("Kitchen(Night)");
        backgroundsName.Add("NailaApartment");
        backgroundsName.Add("Town");
        backgroundsName.Add("Town(Night)");

        backgroundsSprites.Add(background1);
        backgroundsSprites.Add(background2);
        backgroundsSprites.Add(background3);
        backgroundsSprites.Add(background4);
        backgroundsSprites.Add(background5);
        backgroundsSprites.Add(background6);
        backgroundsSprites.Add(background7);
        backgroundsSprites.Add(background8);
        backgroundsSprites.Add(background9);
        backgroundsSprites.Add(background10);
        backgroundsSprites.Add(background11);
        backgroundsSprites.Add(background12);
        backgroundsSprites.Add(background13);

    }
}
