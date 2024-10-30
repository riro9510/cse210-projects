abstract class Goal{
    private string _shortName;
    private string _description;
    private int _points;
    protected string shortName;
    protected string description;
    protected int points;
    public Goal(string name,string description,int points){
        _shortName=name;
        _description=description;
        _points=points;
        this.shortName=_shortName;
        this.description=_description;
        this.points=_points;
    }
    public abstract void RecordEvent();
    public abstract bool isComplete();
    public abstract String GetDetailsString();
    public abstract String GetStringRepresentation();


}