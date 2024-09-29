using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        AllFractions listFractions = new AllFractions();
        Fraction one =new  Fraction();
        Fraction five = new Fraction(5);
        Fraction three_four = new Fraction(3,4);
        Fraction one_three = new Fraction(1,3);
        listFractions.AddMoreFractions(one);
        listFractions.AddMoreFractions(five);
        listFractions.AddMoreFractions(three_four);
        listFractions.AddMoreFractions(one_three);
        listFractions.showAllData();
        
    }
}