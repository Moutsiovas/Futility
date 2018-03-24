using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelAnimation : MonoBehaviour {

    Animator anim;

    void Start()
    {
        /*
        anim = GetComponent<Animator>();
        PlayerDB player = new PlayerDB();
        DataServiceForPlayer dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }
        int dangerPoints = player.DangerPoints;
        anim.SetInteger("dangerPoints", dangerPoints); */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDangerPoints(int dangerPoints)
    {
        anim.SetInteger("dangerPoints", dangerPoints);
    }

    public void Initialize()
    {
        anim = GetComponent<Animator>();
        PlayerDB player = new PlayerDB();
        DataServiceForPlayer dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
        foreach (PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }
        int dangerPoints = player.DangerPoints;
        anim.SetInteger("dangerPoints", dangerPoints);
    }
}
