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
            if (IsReuce())
            {
                return GetReuceScore();
            }

            if (IsWinPoint())
            {
                return GetWinnerScore();
            }
            
            if (IsAdvancePoint())
            {
                return GetAdvantageScore();
            }

            return GetDefaultScore();
        }

        private string GetReuceScore()
        {
            return Player1.Point >= 3 ? "Deuce" : Player1.GetResult() + "-All";
        }

        private string GetAdvantageScore()
        {
            return "Advantage " + GetLeadPlayer().Name;
        }

        private string GetWinnerScore()
        {
            return "Win for " + GetLeadPlayer().Name;
        }

        private string GetDefaultScore()
        {
            return Player1.GetResult() + "-" + Player2.GetResult();
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

        private bool IsWinPoint()
        {
            return GetLeadPlayer().Point >= 4 && GetLeadPlayer().Point - GetBehindPlayer().Point >= 2;
        }

        private bool IsAdvancePoint()
        {
            return GetBehindPlayer().Point >= 3;
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