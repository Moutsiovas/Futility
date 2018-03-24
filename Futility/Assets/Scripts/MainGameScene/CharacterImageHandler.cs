using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImageHandler : MonoBehaviour {
    [Header("Aunt")]
    public Sprite auntMain;
    public Sprite aunt2;
    public Sprite aunt3;
    [Header("Boss")]
    public Sprite bossMain;
    public Sprite boss2;
    [Header("Brother")]
    public Sprite brotherMain;
    public Sprite brother2;
    public Sprite brother3;
    [Header("Cousin")]
    public Sprite cousinMain;
    public Sprite cousin2;
    public Sprite cousin3;
    [Header("Doctor")]
    public Sprite doctorMain;
    public Sprite doctor2;
    public Sprite doctor3;
    [Header("Father")]
    public Sprite fatherMain;
    [Header("Friend")]
    public Sprite friendMain;
    public Sprite friend2;
    public Sprite friend3;
    [Header("Mother")]
    public Sprite motherMain;
    public Sprite mother2;
    public Sprite mother3;
    [Header("Psychiatrist")]
    public Sprite psychiatristMain;
    public Sprite psychiatrist2;
    public Sprite psychiatrist3;
    [Header("Uncle")]
    public Sprite uncleMain;
    public Sprite uncle2;

    List<Sprite> returningSprites;
    Dictionary<string, Sprite> mainSpritesTable;
   
    void Start () {
        Initialize();
    }
	
    public Sprite SetReviewCharacterImage(string name)
    {
        Sprite returningSprite = new Sprite();
        foreach (KeyValuePair<string, Sprite> kvPair in mainSpritesTable)
        {
            if (name.Equals(kvPair.Key))
            {
                returningSprite= kvPair.Value;
                return returningSprite;
            }
        }
        return returningSprite;
    }

    public List<Sprite> SetBackground(ScenarioDB scenario)
    {
        List<Sprite> returningList = new List<Sprite>();
        if(scenario.AmountOfImages == 1)
        {
            foreach (KeyValuePair<string, Sprite> kvPair in mainSpritesTable)
            {
                if (scenario.MainImageName.Equals(kvPair.Key))
                {
                    returningList.Add(kvPair.Value);
                }
            }
            return returningList;
        }
        else
        {
            foreach (KeyValuePair<string, Sprite> kvPair in mainSpritesTable)
            {
                if (scenario.FirstImageName.Equals(kvPair.Key))
                {
                    returningList.Add(kvPair.Value);
                }
                if (scenario.SecondImageName.Equals(kvPair.Key))
                {
                    returningList.Add(kvPair.Value);
                }
            }
            return returningList;
        }
    }

    public List<Sprite> GetMainImages()
    {
        List<Sprite> returningList = new List<Sprite>();
        returningList.Add(motherMain);
        returningList.Add(auntMain);
        returningList.Add(brotherMain);
        returningList.Add(cousinMain);
        returningList.Add(bossMain);
        returningList.Add(friendMain);
        returningList.Add(uncleMain);
        returningList.Add(fatherMain);
        returningList.Add(doctorMain);
        returningList.Add(psychiatristMain);

        return returningList;
    }

    public void Initialize()
    {

        returningSprites = new List<Sprite>();
        mainSpritesTable = new Dictionary<string, Sprite>();

        mainSpritesTable.Add("Vicky", motherMain);
        mainSpritesTable.Add("Clay", auntMain);
        mainSpritesTable.Add("Anna", cousinMain);
        mainSpritesTable.Add("Rory", friendMain);
        mainSpritesTable.Add("Diamond", bossMain);
        mainSpritesTable.Add("Hanz", fatherMain);
        mainSpritesTable.Add("Naila", psychiatristMain);
        mainSpritesTable.Add("Gregory", uncleMain);
        mainSpritesTable.Add("Caleb", brotherMain);
        mainSpritesTable.Add("Benhart", doctorMain);
    }
}
