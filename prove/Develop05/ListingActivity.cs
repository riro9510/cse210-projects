class ListingActivity : Activity
{
    private int _count;               
    private List<string> _prompts;     

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _count = 0; 
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowCountDown(5); 

        List<string> userList = new List<string>();
        Console.WriteLine("Start listing items (type 'done' to finish):");

        var timer = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < timer)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
            userList.Add(input);
            _count++; 
        }

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}