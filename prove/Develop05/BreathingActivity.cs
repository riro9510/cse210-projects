class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine("Breathe out...");
            ShowCountDown(4);
            elapsedTime += 8; 
        }

        DisplayEndingMessage();
    }
}