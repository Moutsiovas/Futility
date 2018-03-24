using SQLite4Unity3d;

public class ScenarioDB{

	[PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Question { get; set; }
    public int AmountOfImages { get; set; }
    public string BackgroundName { get; set; }
    public string MainImageName { get; set; }
    public string FirstImageName { get; set; }
    public string SecondImageName { get; set; }
    public bool IsMonologue { get; set; }
    public bool IsItTheLast { get; set; }
    public bool TimeForOutro { get; set; }
    public bool OnlyOneImage { get; set; }
    
}
