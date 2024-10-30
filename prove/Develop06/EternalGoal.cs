 class EternalGoal : Goal
{    
     public EternalGoal(string name,string description,int points):base(name,description,points){
        Console.WriteLine("You have 0 points");
    }
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! you have earned {points} points");
    }
     public override string GetStringRepresentation()
    {
        
        return $"[  ] {shortName} ({description})";
    }
     public override bool isComplete()
    {
        
        return false; 
    }
    public override string GetDetailsString()
    {
        return $"EternalGoal,{shortName},{description},{points}";
    }
}