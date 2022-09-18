namespace program4
{
    internal class NavigationSystem
    {
        private Point treasureLoc;
        private char[,] GameMap;
        private int Rows { get; }
        private int Columns { get; }
        private int GuessCount { get; }
        private bool won;                      // Might not need
        private readonly IslandGameForm? form; // Might not need
     
        public NavigationSystem(int x, int y)
        {
            Rows = x;
            Columns = y;
            GameMap = new char[x, y];

            // Generate Random Location
            Random rand = new Random();
            treasureLoc = new Point(rand.Next(0,Rows), rand.Next(0,Columns));
            
            // Generate initial Map
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    GameMap[i, j] = '~';
                }
            }
        }

        public string PrintArray()
        {
            string text = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    text += Char.ToString(GameMap[i, j]);
                    text += "  ";
                }
                text += Environment.NewLine;
            }

            return text;
        }

        // TODO: Make this work
        /*public void Guess(int x, int y)
        {
            GuessCount++; // Increment GuessCount
            string after = "";
            won = false;
            if ((x == treasureLoc.X) && (y == treasureLoc.Y))
            {
                form.congratsText.Text = "Congratulations! You won!";
                form.playAgain.Visible = true;
                form.exitButton.Visible = true;
                form.guessButton.Enabled = false;
                won = true;
            }
            else if (GameMap[x, y] == '~')
            {
                if (treasureLoc.X > y)
                    GameMap[x, y] = 'N';
                else if (treasureLoc.X < y)
                    GameMap[x, y] = 'S';
                else if (treasureLoc.Y > x)
                    GameMap[x, y] = 'W';
                else if (treasureLoc.Y < x)
                    GameMap[x, y] = 'E';
                else if (treasureLoc.X == x)
                    GameMap[x, y] = 'C';
                else if (treasureLoc.Y == y)
                    GameMap[x, y] = 'R';

                after = PrintArray();
                UpdateLabelSix(after);
            }
            else
                MessageBox.Show("You've already entered this spot! Try another.");
            after = PrintArray();
            UpdateLabelSix(after);

        } */
    }
}