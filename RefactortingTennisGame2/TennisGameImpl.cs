namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        private Player Player1;
        private Player Player2;

        public TennisGameImpl(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string score = "";

            if (IsReuce())
            {
                return GetReuceScore(score);
            }
            
            score = GetAdvantageScore(score);

            score = GetDefaultScore(score);

            score = GetAdvantageScore(score);

            score = GetWinnerScore(score);

            return score;
        }

        private string GetReuceScore(string score)
        {
            score = Player1.Point >= 3 ? "Deuce" : Player1.GetResult() + "-All";

            return score;
        }

        private string GetAdvantageScore(string score)
        {
            if (GetBehindPlayer().Point >= 3)
            {
                score = "Advantage " + GetLeadPlayer().Name;
            }

            return score;
        }

        private string GetWinnerScore(string score)
        {
            if (Player1.Point >= 4 && Player2.Point >= 0 && (Player1.Point - Player2.Point) >= 2)
            {
                score = "Win for player1";
            }

            if (Player2.Point >= 4 && Player1.Point >= 0 && (Player2.Point - Player1.Point) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }

        private string GetDefaultScore(string score)
        {
            if (Player1.Point > 0 && Player2.Point == 0)
            {
                score = Player1.GetResult() + "-" + Player2.GetResult();
            }

            if (Player2.Point > 0 && Player1.Point == 0)
            {
                score = Player1.GetResult() + "-" + Player2.GetResult();
            }

            if (Player1.Point > Player2.Point && Player1.Point < 4)
            {
                score = Player1.GetResult() + "-" + Player2.GetResult();
            }

            if (Player2.Point > Player1.Point && Player2.Point < 4)
            {
                score = Player1.GetResult() + "-" + Player2.GetResult();
            }

            return score;
        }
        
        public Player GetLeadPlayer()
        {
            return Player1.Point > Player2.Point ? Player1 : Player2;
        }
        
        private Player GetBehindPlayer()
        {
            return Player1.Point > Player2.Point ? Player2 : Player1;
        }

        private bool IsReuce()
        {
            return Player1.Point.Equals(Player2.Point);
        }

        public void P1Score()
        {
            Player1.Point++;
        }

        public void P2Score()
        {
            Player2.Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }
    }
}