namespace FishLeaderBoardApi
{
    /// <summary>
    /// This is mostly meant for json files
    /// </summary>
    public interface IJsonHandler
    {
        /// <summary>
        /// Get a list list of certain objects you have stored in you jsonfile
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public T GetListOfObjectsFromJsonFile<T>(string jsonPath);

        /// <summary>
        /// Add a singular item at the bottom of the list in a json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonPath"></param>
        /// <param name="obj"></param>
        public void WriteOneItemToJsonFile<T>(string jsonPath, T obj);
    }
}
