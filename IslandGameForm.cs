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
    /// Controls the overall flow of the game and GUI components that make
    /// up the game.
    /// </summary>
    public partial class IslandGameForm : Form
    {
        NavigationSystem? navigationSystem;
        
        /// <summary>
        /// Construct the IslandGameForm object and initialize
        /// navigationSystem reference to null. 
        /// </summary>
        public IslandGameForm()
        {
            navigationSystem = null;
            InitializeComponent();
        }

        /// <summary>
        /// Disables "START" button and textboxes in the map creation group.
        /// </summary>
        /// <param name="toggle">true enables, false disables.</param>
        private void ToggleMapCreation(bool toggle)
        {
            StartButton.Enabled = toggle;
            EnterRowsTextBox.Enabled = toggle;
            EnterColumnsTextBox.Enabled = toggle;
        }

        /// <summary>
        /// Disables the "GUESS" button and textboxes in the guess group.
        /// </summary>
        /// <param name="toggle">true enables, false disables.</param>
        private void ToggleGuessing(bool toggle)
        {
            GuessButton.Enabled = toggle;
            EnterITextBox.Enabled = toggle;
            EnterJTextBox.Enabled = toggle;
        }

        /// <summary>
        /// Displays the Victory message box that appears upon winning the
        /// game. Displays number of guesses user won with, and prompts user
        /// to either restart or close the game.
        /// </summary>
        /// <returns> DialogResult.Yes or DialogResult.No depending 
        /// on user selection.</returns>
        private DialogResult ShowWinMessageBox()
        {
            return MessageBox.Show("You won with only " +
                navigationSystem!.GuessCount + " guess(es)!" + 
                Environment.NewLine + Environment.NewLine +
                "Would you like to play again?", "Victory!!!",
                MessageBoxButtons.YesNo);
        }

        /// <summary>
        /// Displays the message box that appears when the user enters an
        /// invalid size during game map creation.
        /// </summary>
        private static void ShowInvalidSizeMessageBox()
        {
            MessageBox.Show("Please enter valid dimensions for the map."
                ,"INVALID DIMENSIONS", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays the message box that appears when the user enters an
        /// invalid guess (not in bounds of map).
        /// </summary>
        private static void ShowInvalidGuessMessageBox()
        {
            MessageBox.Show("Please enter a valid guess within the bounds " +
                "of the map.", "INVALID GUESS", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays the Help message box that appears when the user clicks
        /// the "HELP" button. Provides directions on how to play the game.
        /// </summary>
        private static void ShowHelpMessageBox()
        {
            MessageBox.Show("To start the game, enter the dimensions of the" +
                " map." + Environment.NewLine +
                "The map cannot be 0 x 0 or smaller, nor" +
                " greater than 10 x 10." +
                Environment.NewLine + Environment.NewLine +
                "Once the size is entered and you" +
                " click the \"START\" button, you can begin entering guesses" +
                " and submitting your guess with the \"GUESS\" button." +
                " The indices of the guess must be within the bounds of the" +
                " size of the map. You may keep entering guesses until the" +
                " the island has been found. Once it has been found, you" +
                " will have the option of playing again." +
                Environment.NewLine + Environment.NewLine +
                "Legend for map hints:" +
                Environment.NewLine + "N - Island is North" +
                Environment.NewLine + "S - Island is South" +
                Environment.NewLine + "E - Island is East" +
                Environment.NewLine + "W - Island is West" +
                Environment.NewLine + "R - Island is in this row" +
                Environment.NewLine + "C - Island is in this column" +
                Environment.NewLine + "I - Island has been found",
                "How to Play Find the Tropical Island",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the event for when "HELP" button is pressed. Displays the
        /// a message box with directions on how to play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoButton_Click(object sender, EventArgs e)
        {
            ShowHelpMessageBox();
        }

        /// <summary>
        /// Handles the event for when "START" button is pressed. Takes user
        /// input and generates map (if input is valid, otherwise show error
        /// message box). Toggle map creation group after map is created and
        /// enable guess group.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            string tempNumRows;
            string tempNumCols;
            int numRows;
            int numCols;
            
            tempNumRows= EnterRowsTextBox.Text;
            tempNumCols = EnterColumnsTextBox.Text;

            // Check if strings are valid integers
            if (!(int.TryParse(tempNumRows, out numRows) && 
                int.TryParse(tempNumCols, out numCols)))
            {
                ShowInvalidSizeMessageBox();
            }
            // Check if size is invalid
            else if ((numRows <= 0 || numRows > NavigationSystem.MAXROWS) || 
                ((numCols <= 0) || (numCols > NavigationSystem.MAXCOLUMNS)))
            {
                ShowInvalidSizeMessageBox();
            }
            // Set up the game and disable map creation until game ends
            else
            {
                navigationSystem = new NavigationSystem(numRows, numCols);
                MapSizeLabel.Text = "Size: " + navigationSystem.Size;
                MapLabel.Text = navigationSystem.ToString();
                GuessCountLabel.Text = "Guesses: " + 
                    navigationSystem.GuessCount;
                
                // Disable START button and corresponding textboxes
                ToggleMapCreation(false);

                // Enable GUESS button and corresponding textboxes
                ToggleGuessing(true);
            }
        }

        /// <summary>
        /// Handles the event for when "GUESS" button is pressed. Takes user
        /// input (if valid, otherwise show error message box), then
        /// processes guess, update map, and if game is won, show win message
        /// box and prompt user to play again or end game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuessButton_Click(object sender, EventArgs e)
        {
            string tempI;
            string tempJ;
            int i;
            int j;

            tempI = EnterITextBox.Text;
            tempJ = EnterJTextBox.Text;
            
            // Check if strings are valid integers
            if (!(int.TryParse(tempI, out i) && int.TryParse(tempJ, out j)))
            {
                ShowInvalidGuessMessageBox();
            }
            // Check if guess is invalid
            else if ((i < 0 || i > navigationSystem!.MaxI) || ((j < 0) || 
                (j > navigationSystem.MaxJ)))
            {
                ShowInvalidGuessMessageBox();
            }
            else
            {
                bool isWin = navigationSystem.EvaluateGuess(i, j);
                MapLabel.Text = navigationSystem.ToString();
                GuessCountLabel.Text = $"Guesses: " +
                    navigationSystem.GuessCount;

                if(isWin)
                {
                    DialogResult dialogResult = ShowWinMessageBox();

                    if(dialogResult == DialogResult.Yes)
                    {
                        // Enable START button and corresponding textboxes
                        ToggleMapCreation(true);

                        // Disable GUESS button and corresponding textboxes
                        ToggleGuessing(false);

                        // Clear all game data
                        EnterColumnsTextBox.Text = "";
                        EnterRowsTextBox.Text = "";
                        EnterITextBox.Text = "";
                        EnterJTextBox.Text = "";
                        MapSizeLabel.Text = "Size:";
                        GuessCountLabel.Text = "Guesses:";
                        MapLabel.Text = "";
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }
    }
}