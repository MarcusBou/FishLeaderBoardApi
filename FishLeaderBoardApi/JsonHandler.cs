using System.Text.Json;

namespace FishLeaderBoardApi
{
    public class JsonHandler : IJsonHandler
    {
        public JsonHandler()
        {
        }
        public T GetListOfObjectsFromJsonFile<T>(string jsonPath)
        {
            string json = ReadFile(jsonPath);
            if (json.Equals(String.Empty))
            {
                json = "[]";
            }
            T obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }

        public void WriteOneItemToJsonFile<T>(string jsonPath, T obj)
        {
            List<T> objs = GetListOfObjectsFromJsonFile<List<T>>(jsonPath);
            objs.Add(obj);
            string json = JsonSerializer.Serialize(objs);
            WriteToFile(jsonPath, json);
        }

        public string ReadFile(string filepath)
        {
            if (!File.Exists(filepath)) {return "[]"; }
            string some = File.ReadAllText(filepath);
            return some;
        }

        public void WriteToFile(string filepath, string text)
        {
            File.WriteAllText(filepath, text);
        }
    }
}
