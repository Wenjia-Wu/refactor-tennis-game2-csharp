namespace RefactortingTennisGame2
{
    public class Player
    {
        public string Name;
        public int Point;
        public string Result;
        
        public Player(string name)
        {
            Name = name;
        }

        public string GetResult()
        {
            if (Point == 0)
                Result = "Love";
            if (Point == 1)
                Result = "Fifteen";
            if (Point == 2)
                Result = "Thirty";
            if (Point == 3)
                Result = "Forty";
            return Result;
        }
    }
}