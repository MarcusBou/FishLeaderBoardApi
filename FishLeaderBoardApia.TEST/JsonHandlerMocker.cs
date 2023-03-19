using FishLeaderBoardApi;
using FishLeaderBoardApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FishLeaderBoardApia.TEST
{
    public class JsonHandlerMocker : IJsonHandler
    {
        private string json;
        public string Json { get { return json; } }
        public JsonHandlerMocker(string json)
        {
            this.json = json;
        }

        public T GetListOfObjectsFromJsonFile<T>(string jsonPath)
        {
            T list = JsonSerializer.Deserialize<T>(json);
            return list;
        }

        public void WriteOneItemToJsonFile<T>(string jsonPath, T obj)
        {
            List<T> objs = GetListOfObjectsFromJsonFile<List<T>>(json);
            objs.Add(obj);
            json = JsonSerializer.Serialize(objs);
        }
    }
}
