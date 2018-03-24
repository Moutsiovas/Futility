using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerveHandler : MonoBehaviour {

    Animator anim;
    public int healthPoints;
    public int tempHealthPoints;
    public bool show;
    DataServiceForPlayer dsfp;
    PlayerDB player;


	void Start () {

        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize()
    {
        anim = GetComponent<Animator>();
        healthPoints = 0;
        show = false;
        dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
        foreach(PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }
        healthPoints = player.DangerPoints;
        tempHealthPoints = healthPoints;
    }

    void NerveAnimation()
    {
        if(healthPoints >= 50)
        {
            if(Mathf.Abs(healthPoints - tempHealthPoints) >= 8)
            {
                show = true;
                anim.SetBool("show", show);
                
                Debug.Log("tempHp " + tempHealthPoints);
                tempHealthPoints = healthPoints;
                Debug.Log("tempHp " + tempHealthPoints);
            }
        }
        else
        {
            if (Mathf.Abs(healthPoints - tempHealthPoints) >= 5)
            {
                show = true;
                anim.SetBool("show", show);
                Debug.Log("tempHp " + tempHealthPoints);
                tempHealthPoints = healthPoints;
                Debug.Log("tempHp " + tempHealthPoints);
            }
        }
       
    }

    public void SetShowBool()
    {
        show = false;
        anim.SetBool("show", show);
    }

    public void SetHealthPoints(int hp)
    {
        Debug.Log("Hp " + healthPoints);
        healthPoints = hp;
        if (healthPoints >= 50)
        {
            if (healthPoints - tempHealthPoints > 8)
            {
                tempHealthPoints = healthPoints;
            }
        }
        else
        {
            if (healthPoints - tempHealthPoints > 5)
            {
                tempHealthPoints = healthPoints;
            }
        }
        NerveAnimation();
    }
}
