namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        private Player Player1;
        public Player Player2;

        public TennisGameImpl(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string score = "";
            if (Player1.Point == Player2.Point && Player1.Point < 4)
            {
                if (Player1.Point == 0)
                    score = "Love";
                if (Player1.Point == 1)
                    score = "Fifteen";
                if (Player1.Point == 2)
                    score = "Thirty";
                score += "-All";
            }

            if (Player1.Point == Player2.Point && Player1.Point >= 3)
                score = "Deuce";

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

            if (Player1.Point > Player2.Point && Player2.Point >= 3)
            {
                score = "Advantage player1";
            }

            if (Player2.Point > Player1.Point && Player1.Point >= 3)
            {
                score = "Advantage player2";
            }

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