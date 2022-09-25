// Put comment here

namespace program4
{
    public partial class IslandGameForm : Form
    {
        NavigationSystem? navigationSystem;
        public IslandGameForm()
        {
            navigationSystem = null;
            InitializeComponent();
        }

        private void ToggleMapCreation(bool toggle)
        {
            StartButton.Enabled = toggle;
            EnterRowsTextBox.Enabled = toggle;
            EnterColumnsTextBox.Enabled = toggle;
        }

        private void ToggleGuessing(bool toggle)
        {
            GuessButton.Enabled = toggle;
            EnterITextBox.Enabled = toggle;
            EnterJTextBox.Enabled = toggle;
        }

        private DialogResult ShowWinMessageBox()
        {
            return MessageBox.Show("You won with only " +
                navigationSystem!.GuessCount + " guess(es)!\n\n" +
                "Would you like to play again?", "Victory!!!",
                MessageBoxButtons.YesNo);
        }

        private static void ShowInvalidSizeMessageBox()
        {
            MessageBox.Show("Please enter valid dimensions for the map."
                ,"INVALID DIMENSIONS", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        private static void ShowInvalidGuessMessageBox()
        {
            MessageBox.Show("Please enter a valid guess within the bounds " +
                "of the map.", "INVALID GUESS", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        private static void ShowHelpMessageBox()
        {
            MessageBox.Show("To start the game, enter the dimensions of the" +
                " map.\nThe map cannot be 0 x 0 or smaller, nor" +
                " greater than 10 x 10.\nOnce the size is entered and you" +
                " click the \"START\" button, you can begin entering guesses" +
                " and submitting your guess with the \"GUESS\" button." +
                " The indices of the guess must be within the bounds of the" +
                " size of the map. You may keep entering guesses until the" +
                " the island has been found. Once it has been found, you" +
                " will have the option of playing again.",
                "How to Play Find the Tropical Island",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            ShowHelpMessageBox();
        }

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
            // Check if size is valid
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
            // Check if size is valid
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