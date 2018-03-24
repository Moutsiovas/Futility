using SQLite4Unity3d;

public class PlayerDB
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int DangerPoints { get; set; }
    public int ActIndex { get; set; }
    public int ScenarioIndex { get; set; }
    public int CheckpointIndex { get; set; }
    public int PrologueAnimationIndex { get; set; }

    public int MomPoints { get; set; }
    public int DadPoints { get; set; }
    public int AuntPoints { get; set; }
    public int CousinPoints { get; set; }
    public int FriendPoints { get; set; }
    public int BossPoints { get; set; }
    public int DoctorPoints { get; set; }
    public int NailaPoints { get; set; }
    public int BrotherPoints { get; set; }
    public int MomPointsAct { get; set; }
    public int DadPointsAct { get; set; }
    public int AuntPointsAct { get; set; }
    public int CousinPointsAct { get; set; }
    public int FriendPointsAct { get; set; }
    public int BossPointsAct { get; set; }
    public int DoctorPointsAct { get; set; }
    public int NailaPointsAct { get; set; }
    public int BrotherPointsAct { get; set; }
}
