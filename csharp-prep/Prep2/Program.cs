using System;

class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        
        string letter = "";
        string sign = "";

       
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry! Keep trying for next time.");
        }

        
        if (letter == "A" && gradePercentage < 93)
        {
            sign = "-";
        }
        else if (letter == "B" && gradePercentage >= 87)
        {
            sign = "+";
        }
        else if (letter == "B" && gradePercentage < 83)
        {
            sign = "-";
        }
        else if (letter == "C" && gradePercentage >= 77)
        {
            sign = "+";
        }
        else if (letter == "C" && gradePercentage < 73)
        {
            sign = "-";
        }
        else if (letter == "D" && gradePercentage >= 67)
        {
            sign = "+";
        }
        else if (letter == "D" && gradePercentage < 63)
        {
            sign = "-";
        }
       
        string finalGrade = letter + sign;
        Console.WriteLine($"Your letter grade is: {finalGrade}");
    }
}