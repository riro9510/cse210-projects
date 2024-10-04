using System.Text.RegularExpressions;
class Reference{
    private string _Book{set;get;}
    private int _Chapter{set;get;}
    private int _Verse{set;get;}
    private int? _EndVerse{set;get;}
    
    public Reference(){
        _Book = "";
        _Chapter=0;
        _Verse=0;
        _EndVerse=0;
    }
    public Reference(string reference){
       var match = Regex.Match(reference, @"(?<book>.+?)\s(?<chapter>\d+):(?<verse>\d+)(?:-(?<endVerse>\d+))?");

        if (match.Success)
        {
            _Book = match.Groups["book"].Value;
            _Chapter = int.Parse(match.Groups["chapter"].Value);
            _Verse = int.Parse(match.Groups["verse"].Value);
            if (match.Groups["endVerse"].Success)
            {
                _EndVerse = int.Parse(match.Groups["endVerse"].Value);
            }
        }
        else
        {
            throw new ArgumentException("Invalid scripture reference format.");
        }
    }
    public string GetDisplayText(){
        return _EndVerse!=null?$"{_Book} {_Chapter}:{_Verse}-{_EndVerse}":$"{_Book} {_Chapter}:{_Verse}";
    }
}