using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataServiceForPlayer
{
    private SQLiteConnection _connection;

    public DataServiceForPlayer(string DatabaseName){

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        //Debug.Log("Final PATH: " + dbPath);

    }
    
    /*
    public DataServiceForPlayer(string DatabaseName)
    {

#if UNITY_EDITOR
        string dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        string filepath= string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            WWW loadDb= new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 WWW loadDb= Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                WWW loadDb= Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		WWW loadDb= Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	WWW loadDb= Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        string dbPath= filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        //Debug.Log("Final PATH: " + dbPath);

    }
    */
    public void CreateDB()
    {
        _connection.DropTable<PlayerDB>();
        _connection.CreateTable<PlayerDB>();

        PlayerDB player = new PlayerDB();
        player.Id = 1;
        player.Name = "";
        player.DangerPoints = 100;
        player.ActIndex = 1;
        player.ScenarioIndex = 1;
        player.CheckpointIndex = 1;
        player.PrologueAnimationIndex = 2;


        player.MomPoints = 0;
        player.DadPoints = 0;
        player.AuntPoints = 0;
        player.CousinPoints = 0;
        player.FriendPoints = 0;
        player.BossPoints = 0;
        player.DoctorPoints = 0;
        player.NailaPoints = 0;
        player.BrotherPoints = 0;
        player.MomPointsAct = 0;
        player.DadPointsAct = 0;
        player.AuntPointsAct = 0;
        player.CousinPointsAct = 0;
        player.FriendPointsAct = 0;
        player.BossPointsAct = 0;
        player.DoctorPointsAct = 0;
        player.NailaPointsAct = 0;
        player.BrotherPointsAct = 0;

        _connection.Insert(player);
        
    }

    public void ReplaceData(PlayerDB player)
    {
        _connection.InsertOrReplace(player);
    }

    public IEnumerable<PlayerDB> GetPlayerData()
    {
        return _connection.Table<PlayerDB>();
    }

    public bool HasPlayerData(PlayerDB player, string importance)
    {
        if(player.ScenarioIndex > 1 || player.Name != "")
        {
            if(importance == "name")
            {
                if(player.Name != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if(player.ScenarioIndex > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        else
        {
            return false ;
        }
    }

    public bool HasPlayerPlayed(PlayerDB player)
    {
        if(player.ScenarioIndex >= 2)
        {
            return true;
        }

        return false;
    }

}