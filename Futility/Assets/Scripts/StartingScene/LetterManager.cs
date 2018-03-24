using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {

    Animator anim;
    public bool firstTime;

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Initialize()
    {
        anim = GetComponent<Animator>();
        firstTime = false;
        anim.SetBool("firstTime", firstTime);
    }

    public void ChangeFirstTime()
    {
        if (!firstTime)
        {
            firstTime = true;
            anim.SetBool("firstTime", firstTime);
        }
    }
}
