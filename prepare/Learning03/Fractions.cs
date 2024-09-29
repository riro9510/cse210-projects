class Fraction{
    private int _top;
    private int _bottom;
    public Fraction(){
        _top=1;
        _bottom=1;
    }
    public Fraction(int top){
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    public string GetFractionString(){
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue(){
        return (double)_top/_bottom;
    }
}
class AllFractions{
   private List<Fraction>  _fractions;

   public AllFractions(){
    _fractions = new List<Fraction>();
   }
   public void AddMoreFractions(Fraction fraction){
    _fractions.Add(fraction);
   }
   public void showAllData(){
    foreach(Fraction eachOne in _fractions){
        Console.WriteLine(eachOne.GetFractionString());
        Console.WriteLine(eachOne.GetDecimalValue());
    }
   }
}