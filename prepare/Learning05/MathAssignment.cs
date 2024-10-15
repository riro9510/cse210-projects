class MathAssignment : Assignment 
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string student, string topic, string textbookSection, string problems)
        : base(student, topic) 
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList() 
    {
        return $"Textbook Section: {_textbookSection}, Problems: {_problems}";
    }
}