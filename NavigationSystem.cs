/// Angel Badillo, Blake Gauna
/// 09/27/22
/// Program 4
/// This Windows Form App implements an interactive game that allows the user
/// to create a map within the allowed dimensions of 1x1 up to 10x10. After
/// the map is create, the user may begin entering guesses until they win the
/// game. Once the user wins, the user a message box will appear asking the
/// user to click "Yes" if they want to play again, or click "No" if they want
/// to quit and close the program.
namespace program4
{
    /// <summary>
    /// A simple class that contains the game map, properties to assist with
    /// bound checking and tracking of guesses, as well as a method for
    /// evaluating guesses and converting the map to a string representation.
    /// </summary>
    internal class NavigationSystem
    {
        public const int MAXROWS = 10;
        public const int MAXCOLUMNS = 10;
        private readonly int islandIndexI;
        private readonly int islandIndexJ;
        private char[,] GameMap;
        private int guessCount;
        
        /// <summary>
        /// Returns the total number of rows in the map.
        /// </summary>
        public int Rows { get { return GameMap.GetLength(0); } }
        
        /// <summary>
        /// Returns the total number of columns in the map.
        /// </summary>
        public int Columns { get { return GameMap.GetLength(1); } }
        
        /// <summary>
        /// Returns the maximum i index in the map.
        /// </summary>
        public int MaxI { get { return GameMap.GetUpperBound(0); } }
        
        /// <summary>
        /// Returns the maximum j index in the map.
        /// </summary>
        public int MaxJ { get { return GameMap.GetUpperBound(1); } }
        
        /// <summary>
        /// Returns the guess count property that gets incremented every guess
        /// </summary>
        public int GuessCount { get { return guessCount; } }
        
        /// <summary>
        /// Returns a string representation of the size of the game map.
        /// </summary>
        public string Size
        {
            get
            {
                return Rows.ToString() + " x " + Columns.ToString();
            }
        }

        /// <summary>
        /// Constructs a default NavigationSystem object. The map will be
        /// the maximum possible size by default, which is 10x10.
        /// </summary>
        public NavigationSystem()
        {
            GameMap = new char[MAXROWS, MAXCOLUMNS];
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

        /// <summary>
        /// Constructs a NavigationSystem object. The size must be greater
        /// than 0x0 and can go up to at most 10x10.
        /// </summary>
        /// <param name="numRows">Number of rows in the map.</param>
        /// <param name="numColumns">Number of columns in the map.</param>
        public NavigationSystem(int numRows, int numColumns)
        {
            // If invalid size, default to max size. Else, use size passed in.
            numRows = (numRows > MAXROWS || numRows <= 0) ? MAXROWS : numRows;
            numColumns = (numColumns > MAXCOLUMNS || numColumns <= 0) 
                ? MAXCOLUMNS : numColumns;

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


        /// <summary>
        /// Creates a string representation of NavigationSystem class and
        /// returns it.
        /// </summary>
        /// <returns>  A string representation of Navigation System class.
        /// </returns>
        public override string ToString()
        {
            string text = "  ";

            // Add column indices at the top
            int c = 0;
            while (c < Columns)
                text += c++ + " ";
            text += Environment.NewLine;
            
            // For every row, add row index and each entry in the row
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

        /// <summary>
        /// Takes in indices representing a guess, determines if guess was
        /// correct and returns true. Otherwise, places the appropriate hint
        /// on the map.
        /// </summary>
        /// <param name="i"> Row index of the guess. </param>
        /// <param name="j"> Column index of the guess. </param>
        /// <returns>true if correct guess, false otherwise. </returns>
        public bool EvaluateGuess(int i, int j)
        {
            // If a guess was not made at (i,j), update symbol
            if (GameMap[i, j] == '~')
            {
                guessCount++;
                // Check if guess was correct, return true
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
            // return false if the guess was not correct
            return false;
        }
    }
}