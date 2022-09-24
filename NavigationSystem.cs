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
        public int GuessCount { get { return guessCount; } }

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
            string text = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    text += char.ToString(GameMap[i, j]);
                    text += "  ";
                }
                text += Environment.NewLine;
            }
            return text;
        }

        // TODO: Redo guess method, again :')
        public bool EvaluateGuess(int i, int j)
        {
            if (GameMap[i, j] == '~')
            {
                if ((i == islandIndexI) && (j == islandIndexJ))
                {
                    GameMap[i, j] = 'I';
                    return true;
                }
                else if (islandIndexI == i)
                    GameMap[i, j] = 'R';
                else if (islandIndexJ == j)
                    GameMap[i, j] = 'C';
                else if (islandIndexJ < j && (Math.Abs(i - islandIndexI) == 1))
                    GameMap[i, j] = 'W';
                else if (islandIndexJ > j && (Math.Abs(i - islandIndexI) == 1))
                    GameMap[i, j] = 'E';
                else if (islandIndexI < i)
                    GameMap[i, j] = 'N';
                else if (islandIndexI > i)
                    GameMap[i, j] = 'S';
                guessCount++;

            }
            return false;
        }
    }
}