class ReflectingActivity : Activity
{
    private List<string> _prompts;     
    private List<string> _questions;   

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _prompts = new List<string>
        {
            "Think of a time you stood up for someone else.",
            "Think of a time you did something really difficult.",
            "Think of a time you helped someone in need.",
            "Think of a time you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowCountDown(5); 

        int elapsedTime = 0;
        while (elapsedTime < _duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(5); 
            elapsedTime += 5; 
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }
}