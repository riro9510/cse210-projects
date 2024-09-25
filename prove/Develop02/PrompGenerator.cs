class PromptGenerator
{
   private List<string> prompts = new List<string>
{
    "Who was the most interesting person I interacted with today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today, what would it be?",
    "What is one thing I learned today that surprised me?",
    "What was a challenge I faced today, and how did I handle it?",
    "Who made me smile today, and why?",
    "What is something I am grateful for today?",
    "If I could describe my day in three words, what would they be?"
};


    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }
}