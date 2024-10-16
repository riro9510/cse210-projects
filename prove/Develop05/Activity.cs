class Activity
{
    protected string _name;           
    protected string _description;    
    protected int _duration;          

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
            SetDuration(); 
        }
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name}: {_description}");
        SetDuration();
        Console.WriteLine("Get ready...");
        ShowCountDown(3); 
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Ending {_name}. Well done!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3); 
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + "...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Start!");
    }
     public virtual void Run()
    {
        
    }
}