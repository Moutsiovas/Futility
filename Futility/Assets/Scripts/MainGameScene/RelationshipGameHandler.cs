using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipGameHandler : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public PlayerDB SetRelationshipPoints(PlayerDB player , AnswerDB givenAnswer)
    {
        PlayerDB returningPlayer = player;
        switch (givenAnswer.RelationshipT)
        {
            case RelationshipType.MOM:
                returningPlayer.MomPoints = GiveMomPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.DAD:
                returningPlayer.DadPoints = GiveDadPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.AUNT:
                returningPlayer.AuntPoints = GiveAuntPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.COUSIN:
                returningPlayer.CousinPoints = GiveCousinPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.NAILA:
                returningPlayer.NailaPoints = GiveNailaPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.BOSS:
                returningPlayer.BossPoints = GiveBossPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.FRIEND:
                returningPlayer.FriendPoints = GiveFriendPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.DOCTOR:
                returningPlayer.DoctorPoints = GiveDoctorPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;

            case RelationshipType.BROTHER:
                returningPlayer.BrotherPoints = GiveBrotherPoints(givenAnswer.RelationshipPoints, returningPlayer);
                break;
        }

        return returningPlayer;
    }

    int GiveMomPoints(int amount, PlayerDB player)
    {
        return player.MomPoints + amount;
    }

    int GiveCousinPoints(int amount, PlayerDB player)
    {
        return player.CousinPoints + amount;
    }

    int GiveFriendPoints(int amount, PlayerDB player)
    {
        return player.FriendPoints + amount;
    }

    int GiveBossPoints(int amount, PlayerDB player)
    {
        return player.BossPoints + amount;
    }

    int GiveDoctorPoints(int amount, PlayerDB player)
    {
        return player.DoctorPoints + amount;
    }

    int GiveNailaPoints(int amount, PlayerDB player)
    {
        return player.NailaPoints + amount;
    }

    int GiveDadPoints(int amount, PlayerDB player)
    {
        return player.DadPoints + amount;
    }

    int GiveAuntPoints(int amount, PlayerDB player)
    {
        return player.AuntPoints + amount;
    }

    int GiveBrotherPoints(int amount, PlayerDB player)
    {
        return player.BrotherPoints + amount;
    }
}
