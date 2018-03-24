using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicImageAnimation : MonoBehaviour {

    Animator anim;
    CharacterImageHandler charImageHandler;
    List<Sprite> mainSpriteList;
    Dictionary<Sprite, int> spriteIdentifierDict;
    Sprite showingSprite;
    int identifier;
    int previousIdentifier;

    void Start() {
        
        Initialize();
        InvokeRepeating("SetStateIdentifier" ,0f , 0.5f );
    }

    // Update is called once per frame
    void Update() {
    }

    private void Initialize()
    {
        anim = GetComponent<Animator>();
        charImageHandler = GetComponent<CharacterImageHandler>();
        mainSpriteList = charImageHandler.GetMainImages();
        spriteIdentifierDict = new Dictionary<Sprite, int>();
        showingSprite = GetComponent<Image>().sprite;
        identifier = 0;
        previousIdentifier = -1;

        for (int i=0; i < mainSpriteList.Count; i++)
        {
            spriteIdentifierDict.Add(mainSpriteList[i], i);
        }

        SetStateIdentifier();
    }

    public void SetStateIdentifier()
    {
        Sprite sprite = gameObject.GetComponent<Image>().sprite;
        foreach (KeyValuePair<Sprite, int> kvPair in spriteIdentifierDict)
        {
            if(kvPair.Key == sprite)
            {
                identifier = kvPair.Value;             
            }
        }
        if(gameObject.activeSelf)
        anim.SetInteger("stateIdentifier", identifier); 
    }

    public void CheckStartingImage()
    {
        switch (identifier)
        {
            case 0:
                if(gameObject.GetComponent<Image>().sprite != charImageHandler.motherMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.motherMain;
                }
                break;
            case 1:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.auntMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.auntMain;
                }
                break;
            case 2:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.brotherMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.brotherMain;
                }
                break;
            case 3:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.cousinMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.cousinMain;
                }
                break;
            case 4:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.bossMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.bossMain;
                }
                break;
            case 5:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.friendMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.friendMain;
                }
                break;
            case 6:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.uncleMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.uncleMain;
                }
                break;
            case 7:
                break;
            case 8:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.doctorMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.doctorMain;
                }
                break;
            case 9:
                if (gameObject.GetComponent<Image>().sprite != charImageHandler.psychiatristMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.psychiatristMain;
                }
                break;
        }
    }

    public void ChangeCharacterImage()
    {
        switch (identifier)
        {
            case 0:
                if(gameObject.GetComponent<Image>().sprite == charImageHandler.motherMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.mother2;                
                }
                else if(gameObject.GetComponent<Image>().sprite == charImageHandler.mother2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.mother3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.motherMain;
                }
                break;
            case 1:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.auntMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.aunt2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.aunt2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.aunt3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.auntMain;
                }
                break;
            case 2:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.brotherMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.brother2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.brother2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.brother3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.brotherMain;
                }
                break;
            case 3:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.cousinMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.cousin2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.cousin2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.cousin3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.cousinMain;
                }
                break;
            case 4:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.bossMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.boss2;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.bossMain;
                }
                break;
            case 5:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.friendMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.friend2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.friend2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.friend3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.friendMain;
                }
                break;
            case 6:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.uncleMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.uncle2;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.uncleMain;
                }
                break;
            case 7:
                break;
            case 8:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.doctorMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.doctor2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.doctor2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.doctor3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.doctorMain;
                }
                break;
            case 9:
                if (gameObject.GetComponent<Image>().sprite == charImageHandler.psychiatristMain)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.psychiatrist2;
                }
                else if (gameObject.GetComponent<Image>().sprite == charImageHandler.psychiatrist2)
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.psychiatrist3;
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = charImageHandler.psychiatristMain;
                }
                break;
        }
    }
}
