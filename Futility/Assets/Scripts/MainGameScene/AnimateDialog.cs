using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateDialog : MonoBehaviour
{
    
    
    public MainPanelManager mainManager;

    public bool isAnimationOn = false;
    public float letterSpeed = 0f;

    public IEnumerator AnimateStoryString(string displayString)
    {
        for (int characterIndex = 0; characterIndex <= displayString.Length; characterIndex++)
        {
            //NEW

            //NEW
            yield return new WaitForSeconds(letterSpeed);
            if (mainManager.getAnswerGiven())
            {
               
                mainManager.setAnswerGiven(false);
                break;
            }
            gameObject.GetComponent<Text>().text = displayString.Substring(0, characterIndex);
            isAnimationOn = true;
        }
     
        isAnimationOn = false;
    }

    public bool getIsAnimationOn()
    {
        return isAnimationOn;
    }

    public void StartAnimationCoroutine(string displayString)
    {
        StartCoroutine(AnimateStoryString(displayString));
    }
    
}
