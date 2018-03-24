using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{

    public MainPanelManager mainManager;

    Sprite tempSprite;
    Transform startingTransform;

    private void Start()
    {
        tempSprite = mainManager.getBgSprite();
        gameObject.GetComponent<Image>().sprite = tempSprite;
    }

    public void SetBack()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        

    }
}
