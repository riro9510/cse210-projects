class  SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name,string description,int points):base(name,description,points){
        _isComplete=false;
        Console.WriteLine("You have 0 points");
    }
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! you have earned {points} points");
        _isComplete=true;
    }

    // Método para verificar si la meta está completa
    public override bool isComplete()
    {
        return _isComplete;
    }

    // Método para obtener la representación en cadena de la meta
    public override string GetStringRepresentation()
    {
        // Implementación del método
        return _isComplete?$"[ x ] {shortName} ({description})":$"[ ] {shortName} ({description})";
    }
    public override string GetDetailsString()
    {
         return $"SimpleGoal,{shortName},{description},{points},{_isComplete}";
    }
}