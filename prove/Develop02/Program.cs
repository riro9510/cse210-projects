using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


class Program
{
    private static PromptGenerator _promG = new PromptGenerator();
    private static Journal entrada = new Journal();
    static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("Quit");
            try{
            Console.WriteLine($"What would you like to do:");
            string whatToDo = Console.ReadLine().ToLower();
              int whatToDo2;
            if (int.TryParse(whatToDo, out whatToDo2))
            {
                switch (whatToDo2)
                {
                    case 1:
                        writeEntry();
                        break;
                    case 2:
                        DisplayEntries();
                        break;
                    case 3:
                        LoadFile();
                        break;
                    case 4:
                        ToFile();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else if (whatToDo == "quit")
            {
              Console.WriteLine("Exiting the program.");
                break; // Salir del bucle si el usuario escribe "quit"   
            }else if(whatToDo == "write")
            {
                Console.WriteLine("Registering entry.");
                writeEntry();
            }
            else if(whatToDo == "display")
            {
                Console.WriteLine("Displaying entries.");
                DisplayEntries();
            }
            else if(whatToDo == "load")
            {
                Console.WriteLine("loading file.");
                LoadFile();
            }
            else if(whatToDo == "save")
            {
                Console.WriteLine("saving to file.");
                ToFile();
            }
            }catch(Exception ex){
                 Trace.TraceError($"An error occurred: {ex.Message}\n{ex.StackTrace}");
                 Console.WriteLine("An error has been logged.");
            }
        }
    }
    static void writeEntry(){
        string promptReturning = _promG.GetRandomPrompt();
        Console.WriteLine(promptReturning);
        string response_prompt = Console.ReadLine();
        entrada.addEntry(_prompt:promptReturning,_response:response_prompt);
       
}
    static void DisplayEntries(){
        entrada.Display();
    }
    static void LoadFile(){
        Console.WriteLine("What is the filename(There´s no need to include the extension):");
        string FileName = Console.ReadLine().ToLower();
        entrada.LoadFromFile(FileName);
    }
    static void ToFile(){
        Console.WriteLine("What is the filename(There´s no need to include the extension):");
        string FileName = Console.ReadLine().ToLower();
        entrada.SaveToFile(FileName);
    }
}