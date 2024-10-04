using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        int IndexIteration;
        string userInput;
        do{
        ListScriptures NewInstanceListScriptures = new ListScriptures();
        int IndexGeneralAppScripture = InitialTask(NewInstanceListScriptures); 
         Func<Scripture> ScriptureGetIt = () => GettingScripturesFromJson(IndexGeneralAppScripture,NewInstanceListScriptures);
         Scripture NewPairScripture = ExecuteWithHandling(ScriptureGetIt,"GettingScripture");
         string GetText = NewPairScripture.GetDisplayText();
         string GetRefence = NewPairScripture.GetRefence();
         Action PrintingText = () =>  PrintText(GetText,100);
         ExecuteWithHandling(PrintingText,"Printing Scripture");
         Console.WriteLine(GetRefence);
         
        IndexIteration = 0; 
            do
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine(); 
                IndexIteration = NewPairScripture.HideRandomWords(IndexIteration);
                GetText = NewPairScripture.GetDisplayText();
                GetRefence = NewPairScripture.GetRefence();
                Action PrintingTextBucle = () =>  PrintText(GetText,100);
                ExecuteWithHandling(PrintingTextBucle,"Printing Scripture");
                Console.WriteLine(GetRefence);
            } while (IndexIteration != 0); 

            Console.WriteLine("Press Enter to continue or type 'quit' to finish the program.");
            userInput = Console.ReadLine();
            Console.Clear();
        } while (!userInput.Equals("quit", StringComparison.OrdinalIgnoreCase));
    }
    static public List<Dictionary<string, string>> ReadingJson(){
         string jsonString = File.ReadAllText("scriptures.json");
        List<Dictionary<string, string>> scripturesList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);
        return scripturesList;

    }
  static public List<int>? ReadingJsonMemorizedScriptures()
    {
        string filePath = "IndexUsados.json";
        if (!File.Exists(filePath))
        {
            return null; 
        }
        string fileContent = File.ReadAllText(filePath);
        // Verificar si el contenido es vacío o contiene solo un objeto vacío
        if (string.IsNullOrWhiteSpace(fileContent) || fileContent == "{}")
        {
            return new List<int>(); // Retornar una lista vacía
        }
        try
        {
            // Intentar deserializar el contenido JSON
            List<int> memorizedIndexes = JsonSerializer.Deserialize<List<int>>(fileContent);
            return memorizedIndexes ?? new List<int>(); // Si la deserialización devuelve null, retornar lista vacía
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
            return new List<int>(); // Retornar lista vacía en caso de error
        }
    }
    static public Scripture GettingScripturesFromJson(int IndexToWork,ListScriptures existingList){
        List<Dictionary<string, string>> scripturesList = ReadingJson();
        var ScriptureSelected = scripturesList[IndexToWork];
        string reference="";
        List<Word> ListOfWords = new List<Word>();
        foreach (var kvp in ScriptureSelected) {
            if(kvp.Key=="reference"){
                reference = kvp.Value;
            }else{
                Func<List<Word>> InternList = () =>CreatingListOfWords(kvp.Value);
                ListOfWords=ExecuteWithHandling(InternList,"Getting Internal List");

            }
        }
        Reference ScriptureReference = new Reference(reference);

        Scripture NewPairScripture = new Scripture(ScriptureReference,ListOfWords);
         existingList.AddScripture(NewPairScripture, IndexToWork);
        return NewPairScripture;
    }
    static public List<Word> CreatingListOfWords(string ScriptureContent){
        List<Word> ListOfWords = [];
        string pattern = @"(\w+[,.?;]?|\s+)"; 
        MatchCollection matches = Regex.Matches(ScriptureContent, pattern);
        
        List<string> resultados = new List<string>();

    
        foreach (Match match in matches) {
            if (!string.IsNullOrWhiteSpace(match.Value)) {
                resultados.Add(match.Value);
            }
        }

       
        foreach (var resultado in resultados) {
            Word eachWord = new Word(resultado);
            ListOfWords.Add(eachWord);
        }
        return ListOfWords;
    }
    
    static int InitialTask(ListScriptures List){
        List<Dictionary<string, string>> Scriptures = ReadingJson();
        int total_scriptures = Scriptures.Count;
        Func<int> randomIndexFunc = () => List.GettingRandomIndex(total_scriptures);
        return ExecuteWithHandling(randomIndexFunc,"InitialTask");

    }
    static void PrintText(string text, int maxLineLength)
    {
        string[] words = text.Split(' ');
        List<string> lines = new List<string>();
        string currentLine = "";

        foreach (var word in words)
        {
            if (currentLine.Length + word.Length + 1 > maxLineLength)
            {
                lines.Add(currentLine.Trim()); 
                currentLine = word + " "; 
            }
            else
            {
                currentLine += word + " "; 
            }
        }

        
        if (!string.IsNullOrWhiteSpace(currentLine))
        {
            lines.Add(currentLine.Trim());
        }

        
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
     

   static void ExecuteWithHandling(Action action, string functionName)
    {
        try
        {
            action(); // Ejecuta la función que no retorna valor
        }
        catch (Exception ex)
        {
            HandleException(ex, functionName);
        }
    }

    static T ExecuteWithHandling<T>(Func<T> func, string functionName)
    {
        try
        {
            return func(); // Ejecuta la función y devuelve el resultado
        }
        catch (Exception ex)
        {
            HandleException(ex, functionName);
            return default; // Devuelve el valor por defecto de T en caso de excepción
        }
    }
    static void HandleException(Exception ex, string functionName)
    {
        //StackTrace stackTrace = new StackTrace(ex, true);
        Console.WriteLine($"Exception in function: {functionName}");
        //Console.WriteLine(ex.Message);
        //Console.WriteLine("Stack Trace:");
        //Console.WriteLine(stackTrace.ToString());
    }
}   