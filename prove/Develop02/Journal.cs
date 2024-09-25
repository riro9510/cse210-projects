using System.Text.Json;
class Journal{
    public List<Entry> _entries;
     public Journal()
    {
        _entries = new List<Entry>();
    }
    public void addEntry(string _prompt, string _response){
        _entries.Add(new Entry(prompt:_prompt,response:_response,date:DateTime.Now.ToString("yyyy-MM-dd")));
        
    }
     public void Display()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt} - {entry.Response}");
        }
    }

    public void SaveToFile(string filename)
    {
         var json = JsonSerializer.Serialize(_entries);
    File.WriteAllText(filename+".json", json);
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            var json = File.ReadAllText(filename + ".json");
           // _entries = JsonSerializer.Deserialize<List<Entry>>(json);

            var recover = JsonSerializer.Deserialize<List<Entry>>(json, new JsonSerializerOptions { IncludeFields = true });
            // Asigna la lista deserializada a _entries
             if (recover != null)
            {
            _entries = recover;
                foreach (var entry in recover)
            {
             Console.WriteLine($"Prompt: {entry.Prompt}, Response: {entry.Response}, Date: {entry.Date}");
            }
            }
             else
             {
            _entries = new List<Entry>(); // Inicializa si la deserialización falla
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filename}.json' was not found.");
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"Error: Could not deserialize JSON. {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}