using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Relationship : MonoBehaviour {

    
    int momPoints, dadPoints, cousinPoints, auntPoints, friendPoints, bossPoints, doctorPoints, nailaPoints;

    DataServiceForPlayer dsfp = new DataServiceForPlayer("tempDatabaseForPlayer.db");
    PlayerDB player = new PlayerDB();

    private void Start()
    {
        foreach(PlayerDB _player in dsfp.GetPlayerData())
        {
            player = _player;
        }

        
        momPoints = player.MomPoints;
        dadPoints = player.DadPoints;
        cousinPoints = player.CousinPoints;
        auntPoints = player.AuntPoints;
        friendPoints = player.FriendPoints;
        bossPoints = player.BossPoints;
        doctorPoints = player.DoctorPoints;
        nailaPoints = player.NailaPoints;

        Debug.Log("EIMAI APO RELATIONSHIP SCRIPT KAI MOM: " + player.MomPoints + "    KAI COUSIN   " + player.CousinPoints);
    }


   

	public int getMomPoints()
	{
		return momPoints;
	}

	public void giveDadPoints(int amount)
	{
		dadPoints += amount;
	}

	public int getDadPoints()
	{
		return dadPoints;
	}
   

	public int getCousinPoints()
	{
		return cousinPoints;
	}

	
	public int getAuntPoints()
	{
		return auntPoints;
	}

	public void giveFriendPoints(int amount)
	{
		friendPoints += amount;
	}

	public int getFriendPoints()
	{
		return friendPoints;
	}

	public void giveBossPoints(int amount)
	{
		bossPoints += amount;
	}

	public int getBossPoints()
	{
		return bossPoints;
	}

	public void giveDoctorPoints(int amount)
	{
		doctorPoints += amount;
	}

	public int getDoctorPoints()
	{
		return doctorPoints;
	}

	public void giveNailaPoints(int amount)
	{
		nailaPoints += amount;
	}

	public int getNailaPoints()
	{
		return nailaPoints;
	}
}
