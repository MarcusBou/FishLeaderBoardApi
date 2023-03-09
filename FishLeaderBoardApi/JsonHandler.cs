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
            //If json file is empty insert list clamps for indicating a empty list
            if (json.Equals(String.Empty))
            {
                json = "[]";
            }
            //Deserialize object and return it
            T obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }

        public void WriteOneItemToJsonFile<T>(string jsonPath, T obj)
        {
            //Gets list of objects from the json file
            List<T> objs = GetListOfObjectsFromJsonFile<List<T>>(jsonPath);
            //Adds a singular item to the obj
            objs.Add(obj);
            //Serialize the list
            string json = JsonSerializer.Serialize(objs);
            //Write to the file
            WriteToFile(jsonPath, json);
        }

        /// <summary>
        /// Read a file will return '[]' if the file doesnt exist
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public string ReadFile(string filepath)
        {
            if (!File.Exists(filepath)) {return "[]"; }
            string some = File.ReadAllText(filepath);
            return some;
        }

        /// <summary>
        /// Overwrite the file on the location.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="text"></param>
        public void WriteToFile(string filepath, string text)
        {
            File.WriteAllText(filepath, text);
        }
    }
}
