using System.Text;
class Scripture{
    private Reference _reference { get; set; }
    private List<Word> _words{ get; set; }

    public Scripture(){
        _reference = new Reference();
        _words =new  List<Word>();
    }
    public Scripture(Reference reference, List<Word> word){
        _reference = reference;
        _words = word;

    }
    public Reference Reference => _reference; 
    public IReadOnlyList<Word> Words => _words.AsReadOnly();

    public int HideRandomWords(int NumberToHide){
       int LenghtRecover = this._words.Count;
       List<int> visibleIndices = new List<int>();

    for (int i = 0; i <LenghtRecover ; i++) {
        if (!_words[i].IsHidden()) {
            visibleIndices.Add(i);
        }
    }
    int TotalEnabledWords = visibleIndices.Count;
    List<int> filteredFibonacci = GenerateFibonacciToSum(LenghtRecover);
    
    if(NumberToHide<filteredFibonacci.Count){
        int NextStep = filteredFibonacci[NumberToHide];
        List<int> WordsToHide = GetRandomNumbers(NextStep,visibleIndices);
        foreach(int IndexRevisar in WordsToHide){
            _words[IndexRevisar].Hide();
        }
        if(NumberToHide==filteredFibonacci.Count-1){
            ListScriptures NewList = new ListScriptures();
            NewList.SetMemorizeForScripture(this);
        }
        NumberToHide++;
       return  NumberToHide;
    }
    return 0;
    }
    private List<int> GenerateFibonacciToSum(int targetSum) {
    List<int> fibonacci = new List<int>();
    int a = 0, b = 1;
    
    // Use Fibonnacci until where it´s possible to use
    while (true) {
        // if the new add overcome the target breaks the while
        if (a + b > targetSum) break; 
        fibonacci.Add(a);
        int next = a + b; 
        a = b; 
        b = next; 
    }
    int currentSum = fibonacci.Sum();
    if (currentSum < targetSum) {
        int difference = targetSum - currentSum;
        fibonacci.Add(difference); 
    }
    if (fibonacci.Count > 0 && fibonacci[0] == 0) {
        fibonacci.RemoveAt(0);
    }
    return fibonacci; 
}
private List<int> GetRandomNumbers(int count, List<int> sourceList)
    {

        if (count > sourceList.Count)
        {
            throw new ArgumentException("Number request exced the total.");
        }

        Random random = new Random();
        HashSet<int> selectedIndices = new HashSet<int>(); 
        List<int> result = new List<int>();

        while (result.Count < count)
        {
            int randomIndex = random.Next(0, sourceList.Count);
            if (selectedIndices.Add(randomIndex)) 
            {
                result.Add(sourceList[randomIndex]);
            }
        }

        return result;
    }
    public string GetDisplayText(){
        string _makingString(){
            StringBuilder scriptureDisplay = new StringBuilder();
            foreach(Word eachWordScripture in _words){
                if(!eachWordScripture.IsHidden()){
                 scriptureDisplay.Append($"{eachWordScripture.GetDisplayText()} ");
                }else{
                    scriptureDisplay.Append(" __");
                }
            }
            return scriptureDisplay.ToString();
        }
        string FullText =_makingString();
        return FullText;
    }
     public bool IsCompletelyHidden(){
        foreach(Word words in _words){
            if(!words.IsHidden()){
                return false;
            }
        }
        return true;
    }
    public string GetRefence(){
        return _reference.GetDisplayText();
    }

}