namespace FishLeaderBoardApi.Models
{
    public class Record
    {
        private string name;
        private int highestWeight;
        private int mostFish;
        private int points;

        public string Name { get { return name; } set { name = value; } }
        public int HighestWeight { get { return highestWeight; } set { highestWeight = value; } }
        public int MostFish { get { return mostFish; } set { mostFish = value; } }
        public int Points { get { return points; } set { points = value; } }
    }
}
