namespace program4
{
    internal class NavigationSystem
    {
        private readonly int islandIndexI;
        private readonly int islandIndexJ;
        private char[,] GameMap;
        private int guessCount;
        public int Rows { get { return GameMap.GetLength(0); } }
        public int Columns { get { return GameMap.GetLength(1); } }
        public int MaxI { get { return GameMap.GetUpperBound(0); } }
        public int MaxJ { get { return GameMap.GetUpperBound(1); } }
        public int GuessCount { get { return guessCount; } }
        public string Size
        {
            get
            {
                return Rows.ToString() + " x " + Columns.ToString();
            }
        }

        public NavigationSystem(int numRows, int numColumns)
        {
            GameMap = new char[numRows, numColumns];
            guessCount = 0;
            // Generate Random Location
            Random rand = new Random();
            islandIndexI = rand.Next(0, Rows);
            islandIndexJ = rand.Next(0, Columns);

            // Generate initial Map
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    GameMap[i, j] = '~';
                }
            }
        }


        // String representation of GameMap array
        public override string ToString()
        {
            string text = "  ";
            for (int j = 0; j < Columns; j++)
                text += j + " ";
            text += Environment.NewLine;
            for (int i = 0; i < Rows; i++)
            {
                text += i + " ";
                for (int j = 0; j < Columns; j++)
                {
                    text += char.ToString(GameMap[i, j]);
                    text += " ";
                }
                text += Environment.NewLine;
            }
            return text;
        }

        // TODO: Redo guess method, again :')
        public bool EvaluateGuess(int i, int j)
        {
            guessCount++;

            // If a guess was not made at (i,j), update symbol
            if (GameMap[i, j] == '~')
            {
                // Check if guess was correct
                if ((i == islandIndexI) && (j == islandIndexJ))
                {
                    GameMap[i, j] = 'I';
                    return true;
                }
                // Check if guess is on the same row as island
                else if (islandIndexI == i)
                    GameMap[i, j] = 'R';
                // Check if guess is on the same column a island
                else if (islandIndexJ == j)
                    GameMap[i, j] = 'C';
                // If not the second guess, check if island is west
                else if (islandIndexJ < j && (guessCount % 2 != 0))
                    GameMap[i, j] = 'W';
                // If not second guess, check if island is east
                else if (islandIndexJ > j && (guessCount % 2 != 0))
                    GameMap[i, j] = 'E';
                // If second guess, check if island is north
                else if (islandIndexI < i && guessCount % 2 == 0)
                    GameMap[i, j] = 'N';
                // Island is south otherwise
                else
                    GameMap[i, j] = 'S';
            }
            return false;
        }
    }
}