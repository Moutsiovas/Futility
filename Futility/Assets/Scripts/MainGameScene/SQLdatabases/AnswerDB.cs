using SQLite4Unity3d;

public class AnswerDB
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Answer { get; set; }
    public int DangerPoints { get; set; }
    public int RelationshipPoints { get; set; }
    public RelationshipType RelationshipT { get; set; }
    public int ScenarioIndex { get; set; }
    public int PointingScenarioIndex { get; set; }
    

}
