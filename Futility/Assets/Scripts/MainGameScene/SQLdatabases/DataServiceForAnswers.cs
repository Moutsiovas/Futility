using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataServiceForAnswers
{
    private SQLiteConnection _connection;

    public DataServiceForAnswers(string DatabaseName)
    {

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

    public void CreateDB()
    {
        //_connection.DropTable<AnswerDB>();
        //_connection.CreateTable<AnswerDB>();

        _connection.InsertAll(new[]{
            new AnswerDB {
                Id = 1,
                Answer="(Continue)",
                DangerPoints=0,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.NONE,
                ScenarioIndex=1,
                PointingScenarioIndex=0
                
            },
            new AnswerDB{
                Id = 2,
                Answer="Of course mother, I am gonna tell aunt Clay to stop at a nearby flowering shop.",
                DangerPoints=3,
                RelationshipPoints=2,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=2,
                PointingScenarioIndex=0
            },
             new AnswerDB{
                Id = 3,
                Answer="(Ignores the voice )",
                DangerPoints=0,
                RelationshipPoints=-1,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=2,
                PointingScenarioIndex=0
            },
              new AnswerDB{
                Id = 4,
                Answer="I will discuss it with aunt and Anna and we will see about that.",
                DangerPoints=1,
                RelationshipPoints=1,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=2,
                PointingScenarioIndex=0
            },
               new AnswerDB{
                Id = 5,
                Answer="(Continue)",
                DangerPoints=0,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.NONE,
                ScenarioIndex=3,
                PointingScenarioIndex=0
        },
               new AnswerDB{
                Id = 6,
                Answer="Both good and bad I guess. It's not a big house so I can do the cleaning without much hussle.",
                DangerPoints=0,
                RelationshipPoints=+1,
                RelationshipT=RelationshipType.COUSIN,
                ScenarioIndex=4,
                PointingScenarioIndex=5
        },
               new AnswerDB{
                Id = 7,
                Answer="Alone? Many people come here everyday. We play cards, we talk, although after a while they just disappear.",
                DangerPoints=5,
                RelationshipPoints=-1,
                RelationshipT=RelationshipType.COUSIN,
                ScenarioIndex=4,
                PointingScenarioIndex=6
        },
               new AnswerDB{
                Id = 8,
                Answer="It's good. Finally I have some privacy and alone time but I really need your cooking aunt Clay. I can't eat spaghetti the whole year",
                DangerPoints=-1,
                RelationshipPoints=+2,
                RelationshipT=RelationshipType.COUSIN,
                ScenarioIndex=4,
                PointingScenarioIndex=5
        },
               new AnswerDB{
                Id = 9,
                Answer="It gets really weird sometimes when I start hearing voices and talking with my mother. But that is way better than living with you people.",
                DangerPoints=3,
                RelationshipPoints=-2,
                RelationshipT=RelationshipType.COUSIN,
                ScenarioIndex=4,
                PointingScenarioIndex=6
        },
               new AnswerDB{
                Id = 10,
                Answer="(Continue)",
                DangerPoints=0,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.NONE,
                ScenarioIndex=5,
                PointingScenarioIndex=7
        },
               new AnswerDB{
                Id = 11,
                Answer="(Continue)",
                DangerPoints=0,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.NONE,
                ScenarioIndex=6,
                PointingScenarioIndex=7
        },
                new AnswerDB{
                Id = 12,
                Answer="(Continue)",
                DangerPoints=0,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.NONE,
                ScenarioIndex=7,
                PointingScenarioIndex=0

        },
                new AnswerDB{
                Id = 13,
                Answer="“I am coming to you mother, you better make some of my favorite cookies.” you say while locking the door.",
                DangerPoints=3,
                RelationshipPoints=2,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=8,
                PointingScenarioIndex=0

        },
                new AnswerDB{
                Id = 14,
                Answer="(Smile back nodding for a few seconds and leaving the apartment).",
                DangerPoints=1,
                RelationshipPoints=0,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=8,
                PointingScenarioIndex=0

        },
                new AnswerDB{
                Id = 15,
                Answer="“I don't understand this. Why? Why do you keep coming to me like that after so much time?” you shout while locking the door and leaving your apartment.",
                DangerPoints=2,
                RelationshipPoints=-1,
                RelationshipT=RelationshipType.MOM,
                ScenarioIndex=8,
                PointingScenarioIndex=0

        }
    });
}

    public AnswerDB CreateContinueAnswer(int id , int scenarioIndex , int pointingScenario)
    {
        AnswerDB answer = new AnswerDB();
        answer.Answer = "(Continue).";
        answer.DangerPoints = 0;
        answer.Id = id;
        answer.ScenarioIndex = scenarioIndex;
        answer.RelationshipT = RelationshipType.NONE;
        answer.RelationshipPoints = 0;
        answer.PointingScenarioIndex = pointingScenario;
        _connection.InsertOrReplace(answer);
        return answer;
    }

    public void InsertOrReplaceAnswer(AnswerDB answer)
    {
        _connection.InsertOrReplace(answer);
        
    }

    public void DeleteAnswer(AnswerDB answer)
    {
        _connection.Delete(answer);
    }

    public IEnumerable<AnswerDB> GetAnswers()
    {
        return _connection.Table<AnswerDB>();
    }

    public IEnumerable<AnswerDB> GetSpecificAnswers(int scenarioIndex)
    {
        return _connection.Table<AnswerDB>().Where(x => x.ScenarioIndex == scenarioIndex);
    }

    public IEnumerable<AnswerDB> GetSpecificAnswersByID(int id)
    {
        return _connection.Table<AnswerDB>().Where(x => x.Id == id);
    }

}