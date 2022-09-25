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

        private void InfoButton_Click(object sender, EventArgs e)
        {
            string caption = "How to Play Find the Tropical Island";

            string text = "To start the game, enter the dimensions of the" +
                " map.\nThe map cannot be 0 x 0 or smaller, nor" +
                " greater than 10 x 10.\nOnce the size is entered and you" +
                " click the \"START\" button, you can begin entering guesses" +
                " and submitting your guess with the \"GUESS\" button." +
                " The indices of the guess must be within the bounds of the" +
                " size of the map. You may keep entering guesses until the" +
                " the island has been found. Once it has been found, you" +
                " will have the option of playing again.";
            
            MessageBox.Show(text, caption, MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string text = "Please enter valid dimensions for the map.";
            string caption = "INVALID MAP DIMENSIONS";
            string tempNumRows;
            string tempNumCols;
            int numRows;
            int numCols;
            
            tempNumRows= EnterRowsTextBox.Text;
            tempNumCols = EnterColumnsTextBox.Text;

            // Check if strings are valid integers
            if (!(int.TryParse(tempNumRows, out numRows) && int.TryParse(tempNumCols, out numCols)))
            {
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if size is valid
            else if ((numRows <= 0 || numRows > NavigationSystem.MAXROWS) || 
                ((numCols <= 0) || (numCols > NavigationSystem.MAXCOLUMNS)))
            {
                MessageBox.Show(text,caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Set up the game and disable map creation until game ends
            else
            {
                navigationSystem = new NavigationSystem(numRows, numCols);
                MapSizeLabel.Text = "Size: " + navigationSystem.Size;
                MapLabel.Text = navigationSystem.ToString();
                GuessCountLabel.Text = "Guesses: " + navigationSystem.GuessCount;
                
                // Disable START button and corresponding textboxes until
                // the game ends
                ToggleMapCreation(false);

                // Enable GUESS button and corresponding textboxes until game ends
                ToggleGuessing(true);
            }
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            string text = "Please enter a valid guess within the bounds of " +
                "the map.";
            string caption = "INVALID GUESS";
            string tempI;
            string tempJ;
            int i;
            int j;

            tempI = EnterITextBox.Text;
            tempJ = EnterJTextBox.Text;

            // Check if strings are valid integers
            if (!(int.TryParse(tempI, out i) && int.TryParse(tempJ, out j)))
            {
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check if size is valid
            else if ((i < 0 || i > navigationSystem!.MaxI) || ((j < 0) || 
                (j > navigationSystem.MaxJ)))
            {
                MessageBox.Show(text, caption, MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else
            {
                bool isWin = navigationSystem.EvaluateGuess(i, j);
                MapLabel.Text = navigationSystem.ToString();
                GuessCountLabel.Text = $"Guesses: " +
                    navigationSystem.GuessCount;

                if(isWin)
                {
                    // Enable START button and corresponding textboxes
                    ToggleMapCreation(true);

                    // Disable GUESS button and corresponding textboxes
                    ToggleGuessing(false);

                    DialogResult dialogResult = MessageBox.Show("You Won!!!!", "You Won",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                        return;
                    else
                        Close();
                }
            }
        }
    }
}