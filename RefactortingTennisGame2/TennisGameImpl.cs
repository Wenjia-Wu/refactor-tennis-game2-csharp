namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        public int Player1point = 0;
        public int Player2point = 0;

        public string Player1res = "";
        public string Player2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGameImpl(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score = "";
            if (Player1point == Player2point && Player1point < 4)
            {
                if (Player1point == 0)
                    score = "Love";
                if (Player1point == 1)
                    score = "Fifteen";
                if (Player1point == 2)
                    score = "Thirty";
                score += "-All";
            }

            if (Player1point == Player2point && Player1point >= 3)
                score = "Deuce";

            if (Player1point > 0 && Player2point == 0)
            {
                if (Player1point == 1)
                    Player1res = "Fifteen";
                if (Player1point == 2)
                    Player1res = "Thirty";
                if (Player1point == 3)
                    Player1res = "Forty";

                Player2res = "Love";
                score = Player1res + "-" + Player2res;
            }

            if (Player2point > 0 && Player1point == 0)
            {
                if (Player2point == 1)
                    Player2res = "Fifteen";
                if (Player2point == 2)
                    Player2res = "Thirty";
                if (Player2point == 3)
                    Player2res = "Forty";

                Player1res = "Love";
                score = Player1res + "-" + Player2res;
            }

            if (Player1point > Player2point && Player1point < 4)
            {
                if (Player1point == 2)
                    Player1res = "Thirty";
                if (Player1point == 3)
                    Player1res = "Forty";
                if (Player2point == 1)
                    Player2res = "Fifteen";
                if (Player2point == 2)
                    Player2res = "Thirty";
                score = Player1res + "-" + Player2res;
            }

            if (Player2point > Player1point && Player2point < 4)
            {
                if (Player2point == 2)
                    Player2res = "Thirty";
                if (Player2point == 3)
                    Player2res = "Forty";
                if (Player1point == 1)
                    Player1res = "Fifteen";
                if (Player1point == 2)
                    Player1res = "Thirty";
                score = Player1res + "-" + Player2res;
            }

            if (Player1point > Player2point && Player2point >= 3)
            {
                score = "Advantage player1";
            }

            if (Player2point > Player1point && Player1point >= 3)
            {
                score = "Advantage player2";
            }

            if (Player1point >= 4 && Player2point >= 0 && (Player1point - Player2point) >= 2)
            {
                score = "Win for player1";
            }

            if (Player2point >= 4 && Player1point >= 0 && (Player2point - Player1point) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        public void P1Score()
        {
            Player1point++;
        }

        public void P2Score()
        {
            Player2point++;
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