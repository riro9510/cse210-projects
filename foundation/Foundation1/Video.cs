class Video{
    private string _title;
    private string _author;
    private int _lenghtInSeconds;
    private List<Comment> _comments;
    
    public Video(string title, string author, int lenghtInSeconds){
        _title=title;
        _author=author;
        _lenghtInSeconds=lenghtInSeconds;
        _comments = new List<Comment>();
    }
    public void AddComment(Comment comment){
        _comments.Add(comment);
    }
    public int GetCommentCount() { 
    return _comments.Count; 
    }
    public List<Comment> GetComments() { 
    return _comments; 
}
    public void printInfo(){
        Console.WriteLine("————————------------——-");
        Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lenghtInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in GetComments())
            {
                comment.show();
            }
        Console.WriteLine("————————------------——-");
    }

}