using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class ListScriptures {
    private List<Scripture> _ListScriptures = new List<Scripture>(); // Inicialización
    private List<bool> _Memorize;
    private List<int> _IndexGeneralList;

    public ListScriptures() {
        var savedList = ReadingJsonMemorizedScriptures();

        if (savedList.HasValue) {
            var (memorizeList, indexGeneralList) = savedList.Value;

            _Memorize = memorizeList;
            _IndexGeneralList = indexGeneralList;

            foreach (int index in _IndexGeneralList.ToList()) {
                Scripture temporal = Program.GettingScripturesFromJson(index,this);
                _ListScriptures.Add(temporal);
            }
        } else {
            _Memorize = new List<bool>();
            _IndexGeneralList = new List<int>();
        }
    }

    public void AddScripture(Scripture scriptureToAdd, int indexGeneralList) {
        if (!_IndexGeneralList.Contains(indexGeneralList)) {
        _ListScriptures.Add(scriptureToAdd);
        _Memorize.Add(false);
        _IndexGeneralList.Add(indexGeneralList);
        SavingList();
    } else {
    
    }
    }

    public IReadOnlyList<Scripture> Scriptures => _ListScriptures.AsReadOnly();
    public IReadOnlyList<bool> Memorize => _Memorize.AsReadOnly();
    public IReadOnlyList<int> IndexGeneralList => _IndexGeneralList.AsReadOnly();

    public void SetMemorizeForScripture(Scripture scriptureToFind) {
        int index = _ListScriptures.FindIndex(r => r.GetRefence() == scriptureToFind.GetRefence());

        if (index >= 0) {
            _Memorize[index] = true;
            SavingList();
        } else {
            Console.WriteLine("Reference doesn't exist.");
        }
    }

    public void SavingList() {
        string filePath = "IndexUsados.json";
        var dataToSave = new {
            Memorize = _Memorize,
            IndexGeneralList = _IndexGeneralList
        };
        string jsonString = JsonSerializer.Serialize(dataToSave);
        File.WriteAllText(filePath, jsonString);

        Console.WriteLine("ListScriptures guardada en IndexUsados.json");
    }

    public int GettingRandomIndex(int totalLength) {
        var savedList = ReadingJsonMemorizedScriptures();

        if (savedList == null) {
            return GenerateRandomNumber(totalLength);
        }

        var (memorizeList, indexGeneralList) = savedList.Value;

        int index = memorizeList.FindIndex(r => r == false);
        if (index >= 0) {
            return indexGeneralList[index];
        } else {
            return GenerateRandomNumber(totalLength, indexGeneralList);
        }
    }

    private static (List<bool> Memorize, List<int> IndexGeneralList)? ReadingJsonMemorizedScriptures() {
        string filePath = "IndexUsados.json";

        if (!File.Exists(filePath)) {
            return null; 
        }

        try {
            string json = File.ReadAllText(filePath);
            using (JsonDocument doc = JsonDocument.Parse(json)) {
                List<bool> memorizeList = new List<bool>();
                List<int> indexGeneralList = new List<int>();

                // Extraer datos de JSON
                foreach (JsonElement element in doc.RootElement.GetProperty("Memorize").EnumerateArray()) {
                    memorizeList.Add(element.GetBoolean());
                }
                foreach (JsonElement element in doc.RootElement.GetProperty("IndexGeneralList").EnumerateArray()) {
                    indexGeneralList.Add(element.GetInt32());
                }

                return (memorizeList, indexGeneralList);
            }
        } catch (JsonException ex) {
            Console.WriteLine($"Error al procesar el JSON: {ex.Message}");
            return null;
        } catch (Exception ex) {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return null;
        }
    }

    static private int GenerateRandomNumber(int max, List<int>? restrictedValues = null) {
        Random random = new Random();
        int generatedNumber;

        HashSet<int> restrictedSet = restrictedValues != null ? new HashSet<int>(restrictedValues) : new HashSet<int>();

        do {
            generatedNumber = random.Next(0, max);
        } while (restrictedSet.Contains(generatedNumber));

        return generatedNumber;
    }
}
