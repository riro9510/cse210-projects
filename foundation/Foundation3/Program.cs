using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");
        List<Activity> activities = new List<Activity>();
        Running run = new Running(5.4,30);
        activities.Add(run);
        Cycling bike = new Cycling(10.0,40);
        activities.Add(bike);
        Swimming swimm = new Swimming(20,30);
        activities.Add(swimm);
        foreach(Activity action in activities){
            action.GetSumary();
        }
    }
}