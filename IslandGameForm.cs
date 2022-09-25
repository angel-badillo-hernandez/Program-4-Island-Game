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
            else if ((numRows <= 0 || numRows > NavigationSystem.MAXROWS) || ((numCols <= 0) || (numCols > NavigationSystem.MAXCOLUMNS)))
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
                
                // Disable START button and textboxes until game ends
                StartButton.Enabled = false;
                EnterRowsTextBox.Enabled = false;
                EnterColumnsTextBox.Enabled = false;
            }
        }
    }
}