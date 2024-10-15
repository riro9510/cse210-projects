class Assignment{
    private string _studentName;
    private string _topic;

    public Assignment(string student, string topic){
        _studentName=student;
        _topic = topic;
    }
    public string GetSummary(){
        string summary = $"{_studentName} - {_topic}";
        return summary;
    }
     public string GetStudentName() 
    {
        return _studentName;
    }
}