using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            if (choice == "4") break;

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ListingActivity();
                    break;
                case "3":
                    activity = new ReflectingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
            }

            activity.Run();
        }
    }
}