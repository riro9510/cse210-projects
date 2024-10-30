class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    protected int bonus;

    public ChecklistGoal(string name,string description,int points,int bonus,int target):base(name,description,points){
        _target=target;
        _bonus=bonus;
        _amountCompleted =0;
        this.bonus=bonus;
        Console.WriteLine("You have 0 points");
    }
     public override void RecordEvent()
    {
       if(_amountCompleted<_target){
        _amountCompleted++;
        Console.WriteLine($"Congratulations! you have earned {points} points");
       }else{
        Console.WriteLine($"Congratulations! you have earned {_bonus} points");
       }
    }
     public override bool isComplete()
    {
       return _amountCompleted==_target?true:false;
    }
    public override string GetStringRepresentation()
    {
       return _amountCompleted==_target?$"[ x ] {shortName} ({description})":$"[ ] {shortName} ({description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetDetailsString()
    {
        // Implementación del método
         return $"CheckListGoal,{shortName},{description},{points},{bonus},{_target},{_amountCompleted}";
    }

}