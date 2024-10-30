using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private List<String> _listSave;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _listSave=new List<string>();
    }
    public void Start()
    {
        while (true) 
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                switch (value)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }


    public void DisplayPlayerInfo()
    {
        // Implementación del método
    }

    // Método para listar los nombres de las metas
    public void ListGoalNames()
    {
         Console.WriteLine("The goals are:");
        foreach(Goal eachGoal in _goals){

        }
    }

    // Método para listar los detalles de las metas
    public void ListGoalDetails()
    {
        List<String> goalsStrings = [];
        foreach(Goal eachGoal in _goals){
            goalsStrings.Add(eachGoal.GetDetailsString());
        }
        _listSave=goalsStrings;
    }

    // Método para crear una nueva meta
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Check List Goal");
        Console.Write("Which type of goal would you like to create?: ");

        string input = Console.ReadLine();
    
        if (int.TryParse(input, out int goalType))
        {
            switch (goalType)
            {
                case 1:
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    string pointsInput = Console.ReadLine();
                    if (int.TryParse(pointsInput, out int points))
                    {
                        SimpleGoal newGoal = new SimpleGoal(name, description, points);
                        _goals.Add(newGoal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for points, please enter a number.");
                    }
                    Start();
                    break;
                case 2:
                   Console.Write("What is the name of your goal? ");
                    string name2 = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string description2 = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    string pointsInput2 = Console.ReadLine();
                    if (int.TryParse(pointsInput2, out int points2))
                    {
                        EternalGoal newGoal = new EternalGoal(name2, description2, points2);
                        _goals.Add(newGoal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for points, please enter a number.");
                    }
                    Start();
                    break;
                case 3:
                    Console.Write("What is the name of your goal? ");
                    string name3 = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string description3 = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    string pointsInput3 = Console.ReadLine();
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    string times3 = Console.ReadLine();
                    int timesInt = int.Parse(times3);
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    string bonus3 = Console.ReadLine();
                    int bonusInt = int.Parse(bonus3);
                    if (int.TryParse(pointsInput3, out int points3))
                    {
                        ChecklistGoal newGoal = new ChecklistGoal(name3, description3, points3,timesInt,bonusInt);
                        _goals.Add(newGoal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for points, please enter a number.");
                    }
                    Start();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number.");
        }
        Start();
    }

    // Método para registrar un evento
    public void RecordEvent()
    {
       Console.WriteLine("The Goals are:");
         for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
    }
    }

    // Método para guardar las metas
    public void SaveGoals()
    {
        Console.WriteLine("Enter the name for your file(without extension): ");
        String rutaArchivo = Console.ReadLine();
        ListGoalDetails();
        using (StreamWriter writer = new StreamWriter(rutaArchivo)){
             string clave = _score.ToString();
            string jsonValores = JsonSerializer.Serialize(_listSave);
            writer.WriteLine($"{clave}:{jsonValores}");
        }
    }

    // Método para cargar las metas
    public void LoadGoals()
    {
        // Implementación del método
    }
}