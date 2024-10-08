class Comment{
    private string _name;
    private string _text;
    public Comment(string name, string text){
        _name=name;
        _text=text;
    }
    public void show(){
	Console.WriteLine($"Comment: {_text}");
	Console.WriteLine($"Usuario: {_name}");
    Console.WriteLine("———-");
}

}