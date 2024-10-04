class Word{
    private string _text;
    private bool _isHidden;
    
    public Word(String WordScripture){
        _text =WordScripture;
        _isHidden = false;
    }

    public void Hide(){
        _isHidden = true;
    }
    public string Show(){
        return _text;
    }
    public bool IsHidden(){
         if(_isHidden==true){
            return true;
        }else{
            return false;
        }
    }
    public string GetDisplayText(){
            return _text;
    }
}